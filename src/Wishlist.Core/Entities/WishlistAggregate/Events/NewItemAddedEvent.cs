using Wishlist.SharedKernel;

namespace Wishlist.Core.Entities.WishlistAggregate.Events;

public class NewItemAddedEvent : DomainEventBase
{
    public WishlistItem NewItem { get; set; }
    public Wishlist Wishlist { get; set; }

    public NewItemAddedEvent(Wishlist wishlist, WishlistItem newItem)
    {
        Wishlist = wishlist;
        NewItem = newItem;
    }
}