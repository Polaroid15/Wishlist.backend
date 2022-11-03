using Wishlist.SharedKernel;

namespace Wishlist.Core.Entities.WishlistAggregate.Events; 

public class WishlistUpdatedEvent : DomainEventBase {
    public WishlistUpdatedEvent(Wishlist wishlist) {
        Wishlist = wishlist;
    }

    public Wishlist Wishlist { get; set; }
}