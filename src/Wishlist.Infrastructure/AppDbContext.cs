using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Wishlist.Application.Common.Interfaces;
using Wishlist.Domain.Common;
using Wishlist.Domain.Entities;
using Wishlist.Domain.Events;
using Wishlist.Infrastructure.Identity;
using Wishlist.Infrastructure.Persistence.Interceptors;

namespace Wishlist.Infrastructure;

public class AppDbContext  : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
{
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;
    private readonly IDomainEventDispatcher? _dispatcher;

    public AppDbContext(
        DbContextOptions<AppDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions,
        IDomainEventDispatcher? dispatcher,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
        : base(options, operationalStoreOptions)
    {
        _dispatcher = dispatcher;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    public DbSet<WishlistItem> WishlistItems => Set<WishlistItem>();
    public DbSet<Domain.Entities.Wishlist> Wishlists => Set<Domain.Entities.Wishlist>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        if (_dispatcher == null) return result;

        var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToArray();

        await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

        return result;
    }
}