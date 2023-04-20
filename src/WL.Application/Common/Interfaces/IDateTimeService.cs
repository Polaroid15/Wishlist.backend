namespace WL.Application.Common.Interfaces;

public interface IDateTimeService
{
    DateTimeOffset CurrentUtcDate { get; }
}