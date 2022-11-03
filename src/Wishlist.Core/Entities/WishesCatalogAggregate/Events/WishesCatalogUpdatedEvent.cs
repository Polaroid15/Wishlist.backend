using Wishlist.SharedKernel;

namespace Wishlist.Core.Entities.WishesCatalogAggregate.Events; 

public class WishesCatalogUpdatedEvent : DomainEventBase {
    public WishesCatalog WishesCatalog { get; set; }

    public WishesCatalogUpdatedEvent(WishesCatalog wishesCatalog) {
        WishesCatalog = wishesCatalog;
    }
}