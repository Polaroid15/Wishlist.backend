using System;
using WL.Application.Common.Interfaces;

namespace WL.Infrastructure.Services;

public class DateTimeService : IDateTimeService
{
    public DateTimeOffset CurrentUtcDate => DateTimeOffset.UtcNow;
}