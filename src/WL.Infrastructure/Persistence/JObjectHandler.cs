using System.Data;
using Dapper;
using Newtonsoft.Json.Linq;
using Npgsql;
using NpgsqlTypes;

namespace WL.Infrastructure.Persistence;

public class JObjectHandler : SqlMapper.TypeHandler<JObject>
{
    private JObjectHandler() { }
    public static JObjectHandler Instance { get; } = new();
    public override JObject Parse(object value)
    {
        var json = (string)value;
        return json == null ? null : JObject.Parse(json);
    }
    
    public override void SetValue(IDbDataParameter parameter, JObject value) {
        if (parameter is NpgsqlParameter p) {
            p.NpgsqlDbType = NpgsqlDbType.Jsonb;
            p.NpgsqlValue = value?.ToString(Newtonsoft.Json.Formatting.None);
        }
    }
}