namespace WL.Domain.Enums;

public class PriorityLevel : Enumeration
{
    public static PriorityLevel None = new(0, nameof(None));
    public static PriorityLevel Low = new(0, nameof(Low));
    public static PriorityLevel Medium = new(0, nameof(Medium));
    public static PriorityLevel High = new(0, nameof(High));

    public PriorityLevel(int id, string name)
        : base(id, name)
    { }
}