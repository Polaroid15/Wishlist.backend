using Wishlist.Core.Entities.WishlistAggregate;
using Wishlist.SharedKernel;

namespace Wishlist.Core.Entities.WishesCatalogAggregate.Events; 

public class NewWishesCatalogItemAddEvent : DomainEventBase {
    public WishesCatalog WishesCatalog { get; set; }

    public WishlistItem WishlistItem { get; set; }

    public NewWishesCatalogItemAddEvent(WishesCatalog wishesCatalog, WishlistItem wishlistItem) {
        WishesCatalog = wishesCatalog;
        WishlistItem = wishlistItem;
    }
}