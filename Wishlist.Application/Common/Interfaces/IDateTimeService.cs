namespace Wishlist.Application.Common.Interfaces;

public interface IDateTimeService
{
    DateTimeOffset CurrentUtcDate { get; }
}