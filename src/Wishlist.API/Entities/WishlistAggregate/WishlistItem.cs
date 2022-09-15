using Ardalis.GuardClauses;
using Wishlist.Core.Entities;

namespace Wishlist.API.Entities.WishlistAggregate; 

public class WishlistItem : BaseEntity {
    
    public int Quantity { get; private set; }
    public int CatalogItemId { get; private set; }
    public int WishlistId { get; private set; }

    public WishlistItem(int catalogItemId, int quantity)
    {
        CatalogItemId = catalogItemId;
        Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);
        Quantity = quantity;
    }

    public void AddQuantity(int quantity)
    {
        Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);

        Quantity += quantity;
    }
}