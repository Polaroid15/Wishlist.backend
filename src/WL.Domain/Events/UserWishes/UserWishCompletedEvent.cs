using WL.Domain.Entities;

namespace WL.Domain.Events.UserWishes;

public record UserWishCompletedEvent(WishlistItem WishlistItem) : DomainEventBase;