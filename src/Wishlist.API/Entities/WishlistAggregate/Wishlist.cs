using Ardalis.GuardClauses;
using Wishlist.Core.Entities;
using Wishlist.Core.Interfaces;

namespace Wishlist.API.Entities.WishlistAggregate; 

public class Wishlist : BaseEntity, IAggregateRoot {
    
    public long UserId { get; private set; }
    
    private readonly List<WishlistItem> _items = new List<WishlistItem>();
    
    public IReadOnlyCollection<WishlistItem> Items => _items.AsReadOnly();
    
    public int TotalItems => _items.Sum(i => i.Quantity);

    public Wishlist(long userId) {
        UserId = userId;
    }
    
    public void AddItem(int catalogItemId, int quantity = 1)
    {
        if (Items.All(i => i.CatalogItemId != catalogItemId))
        {
            _items.Add(new WishlistItem(catalogItemId, quantity));
            return;
        }
        var existingItem = Items.FirstOrDefault(i => i.CatalogItemId == catalogItemId);
        existingItem.AddQuantity(quantity);
    }

    public void RemoveEmptyItems()
    {
        _items.RemoveAll(i => i.Quantity == 0);
    }
}