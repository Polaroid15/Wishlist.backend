using Wishlist.SharedKernel;

namespace Wishlist.Core.Entities.WishlistAggregate.Events; 

public class WishlistItemUpdatedEvent : DomainEventBase {
    
    public WishlistItem UpdatedItem { get; set; }

    public WishlistItemUpdatedEvent(WishlistItem updatedItem)
    {
        UpdatedItem = updatedItem;
    }
}