using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Wishlist.Core.Entities.WishlistAggregate.Events;
using Wishlist.SharedKernel;
using Wishlist.SharedKernel.Interfaces;

namespace Wishlist.Core.Entities.WishlistAggregate;

public class Wishlist : BaseEntity, IAggregateRoot
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    public long UserId { get; private set; }

    private readonly List<WishlistItem> _items = new List<WishlistItem>();

    //TODO : change adding logic from catalog to personal wishlist
    public IReadOnlyCollection<WishlistItem> Items => _items.AsReadOnly();

    public Wishlist(long userId)
    {
        UserId = userId;
    }
    
    public void AddItem(WishlistItem wishlistItem)
    {
        if (Items.All(i => i.Id != wishlistItem.Id))
        {
            var newItem = new WishlistItem(wishlistItem.Title, wishlistItem.Description, wishlistItem.CatalogItemId, wishlistItem.WishlistId);
            _items.Add(newItem);
            RegisterDomainEvent(new NewItemAddedEvent(this, newItem));
        }
    }

    public void UpdateTitle(string newTitle)
    {
        Title = Guard.Against.NullOrEmpty(newTitle, nameof(newTitle));
    }
}