using Wishlist.Core.Entities.WishlistAggregate;
using Wishlist.SharedKernel;

namespace Wishlist.Core.Entities.WishesCatalogAggregate.Events; 

public class ExistWishesCatalogItemRemovedEvent : DomainEventBase {
    public WishesCatalog WishesCatalog { get; set; }
    public WishlistItem WishlistItem { get; set; }

    public ExistWishesCatalogItemRemovedEvent(WishesCatalog wishesCatalog, WishlistItem wishlistItem) {
        WishesCatalog = wishesCatalog;
        WishlistItem = wishlistItem;
    }
}