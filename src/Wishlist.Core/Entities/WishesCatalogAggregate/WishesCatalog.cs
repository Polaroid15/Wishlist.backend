using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Wishlist.Core.Entities.WishesCatalogAggregate.Events;
using Wishlist.Core.Entities.WishlistAggregate;
using Wishlist.SharedKernel;
using Wishlist.SharedKernel.Interfaces;

namespace Wishlist.Core.Entities.WishesCatalogAggregate; 

public class WishesCatalog : BaseEntity, IAggregateRoot {
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    private readonly List<WishlistItem> _items = new List<WishlistItem>();

    public IReadOnlyCollection<WishlistItem> Items => _items.AsReadOnly();
    
    public WishesCatalog() { }

    public void AddItem(WishlistItem item) {

        if (Items.All(i => i.Id != item.Id))
        {
            var newItem = new WishlistItem(item.Title, item.Description, item.CatalogItemId, item.WishlistId);
            _items.Add(newItem);
            RegisterDomainEvent(new NewWishesCatalogItemAddEvent(this, newItem));
        }
    }
    
    public void RemoveItem(WishlistItem wishlistItem) {
        var item = Items.FirstOrDefault(i => i.Id == wishlistItem.Id);
        if (item != null)
        {
            _items.Remove(item);
            RegisterDomainEvent(new ExistWishesCatalogItemRemovedEvent(this, item));
        }
    }

    public void UpdateTitle(string newTitle)
    {
        Title = Guard.Against.NullOrEmpty(newTitle, nameof(newTitle));
        RegisterDomainEvent(new WishesCatalogUpdatedEvent(this));
    }
    
    
    public void UpdateDescription(string newDescription)
    {
        Description = Guard.Against.NullOrEmpty(newDescription, nameof(newDescription));
        RegisterDomainEvent(new WishesCatalogUpdatedEvent(this));
    }
    
    public override string ToString() => $"{Id}: {Title} - {Description}";
}