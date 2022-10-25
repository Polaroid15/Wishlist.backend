using System.Text.Json;

namespace Wishlist.Core.Extensions;

public static class JsonExtensions
{
    private static readonly JsonSerializerOptions _jsonOptions = new() { PropertyNameCaseInsensitive = true };

    public static T FromJson<T>(this string json) => JsonSerializer.Deserialize<T>(json, _jsonOptions)!;

    public static string ToJson<T>(this T obj) => JsonSerializer.Serialize(obj, _jsonOptions);
}