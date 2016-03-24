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

            var value = Convert.ChangeType(reader.Value, destType);

            var xtype = otype.MakeGenericType(destType);

            return Activator.CreateInstance(xtype, value);
        }

        private static Type itype = typeof (IOptional);

        private static Type otype = typeof (Optional<>);

        public override bool CanConvert(Type objectType)
        {
            return itype.IsAssignableFrom(objectType);
        }
    }
}