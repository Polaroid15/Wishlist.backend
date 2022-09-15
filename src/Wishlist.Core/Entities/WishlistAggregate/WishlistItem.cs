using Ardalis.GuardClauses;
using Wishlist.Core.Entities.WishlistAggregate.Events;
using Wishlist.SharedKernel;

namespace Wishlist.Core.Entities.WishlistAggregate; 

public class WishlistItem : BaseEntity {
    
    public string Title { get; private set; }
    public string Description { get; private set; }
    
    public int CatalogItemId { get; private set; }
    
    public int WishlistId { get; private set; }
    
    public bool IsDone { get; private set; }

    public WishlistItem(string title, string description, int catalogItemId, int wishlistId) {
        Title = Guard.Against.NullOrEmpty(title, nameof(title));
        Description = Guard.Against.NullOrEmpty(description, nameof(description));
        CatalogItemId = Guard.Against.OutOfRange(catalogItemId, nameof(catalogItemId), 0, int.MaxValue);
        WishlistId = Guard.Against.OutOfRange(wishlistId, nameof(wishlistId), 0, int.MaxValue);
    }

    public void MarkComplete()
    {
        if (!IsDone)
        {
            IsDone = true;

            RegisterDomainEvent(new WishlistItemUpdatedEvent(this));
        }
    }

    public void UpdateTitle(string newTitle)
    {
        Title = Guard.Against.NullOrEmpty(newTitle, nameof(newTitle));
        RegisterDomainEvent(new WishlistItemUpdatedEvent(this));
    }
    
    public void UpdateDescription(string newDescription)
    {
        Description = Guard.Against.NullOrEmpty(newDescription, nameof(newDescription));
        RegisterDomainEvent(new WishlistItemUpdatedEvent(this));
    }
    
    public override string ToString()
    {
        string status = IsDone ? "Done!" : "Not done.";
        return $"{Id}: Status: {status} - {Title} - {Description}";
    }
}