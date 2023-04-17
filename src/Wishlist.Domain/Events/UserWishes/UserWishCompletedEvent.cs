using Wishlist.Domain.Entities;

namespace Wishlist.Domain.Events.UserWishes;

public record UserWishCompletedEvent(WishlistItem WishlistItem) : DomainEventBase;