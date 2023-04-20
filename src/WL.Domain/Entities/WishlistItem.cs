using WL.Domain.Common;
using WL.Domain.Events.UserWishes;

namespace WL.Domain.Entities;

public class WishlistItem : BaseEntity
{
    private bool _isDone;
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public int CatalogItemId { get; private set; }
    public int WishlistId { get; private set; }

    public bool IsDone
    {
        get => _isDone;
        set
        {
            if (value && !_isDone)
            {
                AddDomainEvent(new UserWishCompletedEvent(this));
            }

            _isDone = value;
        }
    }
    public override string ToString()
    {
        var status = IsDone ? "Done!" : "Not done.";
        return $"{Id}: Status: {status} - {Title} - {Description}";
    }
}