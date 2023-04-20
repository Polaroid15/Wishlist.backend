using WL.Domain.Common;

namespace WL.Domain.Entities;

public class Wishlist : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public long UserId { get; private set; }

    public List<WishlistItem> Items => new();

    public override string ToString() => $"{Id}: {Title} - {Description} - userId:{UserId}";
}