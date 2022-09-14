using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace premperor
{

    public class Util
    {
        public static System.Dynamic.ExpandoObject ParseJson(string json)
        {
            using var document = System.Text.Json.JsonDocument.Parse(json);
            return toExpandoObject(document.RootElement);
            static object propertyValue(System.Text.Json.JsonElement elm) =>
                elm.ValueKind switch
                {
                    System.Text.Json.JsonValueKind.Null => null,
                    System.Text.Json.JsonValueKind.Number => elm.GetDecimal(),
                    System.Text.Json.JsonValueKind.String => elm.GetString(),
                    System.Text.Json.JsonValueKind.False => false,
                    System.Text.Json.JsonValueKind.True => true,
                    System.Text.Json.JsonValueKind.Array => elm.EnumerateArray().Select(m => propertyValue(m)).ToArray(),
                    _ => toExpandoObject(elm),
                };
            static System.Dynamic.ExpandoObject toExpandoObject(System.Text.Json.JsonElement elm) =>
                elm.EnumerateObject()
                .Aggregate(
                    new System.Dynamic.ExpandoObject(),
                    (exo, prop) => { ((IDictionary<string, object>)exo).Add(prop.Name, propertyValue(prop.Value)); return exo; });
        }
    }
}
