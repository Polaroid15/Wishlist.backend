using Wishlist.SharedKernel;

namespace Wishlist.Core.Entities.WishlistAggregate.Events; 

public class ExistItemRemovedEvent : DomainEventBase {
    public WishlistItem WishlistItem { get; set; }
    public Wishlist Wishlist { get; set; }

    public ExistItemRemovedEvent(Wishlist wishlist, WishlistItem wishlistItem) {
        WishlistItem = wishlistItem;
        Wishlist = wishlist;
    }
}