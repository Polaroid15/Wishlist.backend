using System;
using Wishlist.Application.Common.Interfaces;

namespace Wishlist.Infrastructure.Services;

public class DateTimeService : IDateTimeService
{
    public DateTimeOffset CurrentUtcDate => DateTimeOffset.UtcNow;
}