using System.Reflection;

namespace WL.Domain.Common;

public class ValueObject : IEquatable<ValueObject>
{
    private List<PropertyInfo>? _properties;
    private List<FieldInfo>? _fields;

    public static bool operator ==(ValueObject? obj1, ValueObject? obj2)
    {
        if (Equals(obj1, null))
        {
            if (Equals(obj2, null))
            {
                return true;
            }

            return false;
        }

        return obj1.Equals(obj2);
    }

    public static bool operator !=(ValueObject? obj1, ValueObject? obj2) => !(obj1 == obj2);

    public bool Equals(ValueObject? obj) => Equals(obj as object);

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;

        return GetProperties().All(p => PropertiesAreEqual(obj, p))
               && GetFields().All(f => FieldsAreEqual(obj, f));
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_properties, _fields);
    }

    private bool PropertiesAreEqual(object obj, PropertyInfo p) => Equals(p.GetValue(this, null), p.GetValue(obj, null));

    private bool FieldsAreEqual(object obj, FieldInfo f) => Equals(f.GetValue(this), f.GetValue(obj));

    private IEnumerable<PropertyInfo> GetProperties()
    {
        return _properties ??= GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
    }

    private IEnumerable<FieldInfo> GetFields()
    {
        return _fields ??= GetType().GetFields(BindingFlags.Instance | BindingFlags.Public).ToList();
    }
}