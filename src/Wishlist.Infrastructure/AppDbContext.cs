using Microsoft.EntityFrameworkCore;
using Wishlist.Core.Entities.WishlistAggregate;
using Wishlist.SharedKernel;
using Wishlist.SharedKernel.Interfaces;

namespace Wishlist.Infrastructure; 

public class AppDbContext : DbContext {
    private readonly IDomainEventDispatcher? _dispatcher;

    public AppDbContext(DbContextOptions<AppDbContext> options, IDomainEventDispatcher? dispatcher)
        : base(options)
    {
        _dispatcher = dispatcher;
    }

    public DbSet<WishlistItem> WishlistItems => Set<WishlistItem>();
    public DbSet<Core.Entities.WishlistAggregate.Wishlist> Wishlists => Set<Core.Entities.WishlistAggregate.Wishlist>();


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        if (_dispatcher == null) return result;

        var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToArray();

        await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

        return result;
    }

    public override int SaveChanges() => SaveChangesAsync().GetAwaiter().GetResult();
}