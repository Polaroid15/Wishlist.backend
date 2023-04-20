using WL.Application.Common.Interfaces;

namespace WL.Infrastructure.Persistence.Repositories;

public class WishlistRepository : GenericRepository<Domain.Entities.Wishlist>, IWishlistRepository
{

    public WishlistRepository(AppDbContext dbContext) : base(dbContext)
    { }
}