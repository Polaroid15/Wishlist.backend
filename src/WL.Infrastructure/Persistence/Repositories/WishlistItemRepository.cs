using WL.Application.Common.Interfaces;

namespace WL.Infrastructure.Persistence.Repositories;

public class WishlistItemRepository : GenericRepository<Domain.Entities.WishlistItem>, IWishlistItemRepository
{

    public WishlistItemRepository(AppDbContext dbContext) : base(dbContext)
    { }
}