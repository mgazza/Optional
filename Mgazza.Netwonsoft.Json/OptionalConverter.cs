using System;
using Mgazza.Optional;

namespace Newtonsoft.Json
{

    public class OptionalJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var item = (IOptional) value;

            writer.WriteValue(item.Value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var destType = objectType.GetGenericArguments()[0];

            var u = Nullable.GetUnderlyingType(destType);

            var value = u != null
                ? (reader.Value == null ? Activator.CreateInstance(u) : Convert.ChangeType(reader.Value, u))
                : Convert.ChangeType(reader.Value, destType);

            var xtype = Otype.MakeGenericType(destType);

            return Activator.CreateInstance(xtype, value);


        }

        private static readonly Type Itype = typeof (IOptional);

        private static readonly Type Otype = typeof (Optional<>);

        public override bool CanConvert(Type objectType)
        {
            return Itype.IsAssignableFrom(objectType);
        }

       
    }
}