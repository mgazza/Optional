using System;
using Machine.Specifications;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Shouldly;

namespace Mgazza.Optional.Tests.Newtonsoft.Json
{
    public class OptionalSpec
    {
       
        private static JsonSerializerSettings GetDefaultSettings()
        {
            var settings = new JsonSerializerSettings();

            settings.Converters.Add(new OptionalJsonConverter());
            settings.NullValueHandling = NullValueHandling.Ignore;

            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.NullValueHandling = NullValueHandling.Include;
            settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            settings.DateParseHandling = DateParseHandling.DateTimeOffset;

            return settings;
        }

        public class OptionalClass
        {
            public Optional<string> String { get; set; }

            public Optional<int> Int { get; set; }

            public Optional<int?> NullableInt { get; set; }
        }
       

        public class When_deserialising_with_missing_properties_to_an_optional_class1
        {
            public static OptionalClass Result;

            private Because _of = () =>
            {
                Result=JsonConvert.DeserializeObject<OptionalClass>(Json.Test1, GetDefaultSettings());
            };

            private It _should_have_set_String = () => Result.String.HasBeenSet.ShouldBeTrue();

            private It _should_not_have_set_Int = () => Result.Int.HasBeenSet.ShouldBeFalse();

            private It _should_have_set_NullableInt = () => Result.NullableInt.HasBeenSet.ShouldBeTrue();
        }
        public class When_deserialising_with_missing_properties_to_an_optional_class2
        {
            public static OptionalClass Result;

            private Because _of = () =>
            {
                Result = JsonConvert.DeserializeObject<OptionalClass>(Json.Test2, GetDefaultSettings());
            };

            private It _should_have_set_String = () => Result.String.HasBeenSet.ShouldBeTrue();

            private It _should_not_have_set_Int = () => Result.Int.HasBeenSet.ShouldBeFalse();

            private It _should_have_set_NullableInt = () => Result.NullableInt.HasBeenSet.ShouldBeTrue();
        }

        public class When_deserialising_with_missing_properties_to_an_optional_class3
        {
            public static OptionalClass Result;

            private Because _of = () =>
            {
                Result = JsonConvert.DeserializeObject<OptionalClass>(Json.Test3, GetDefaultSettings());
            };

            private It _should_not_have_set_String = () => Result.String.HasBeenSet.ShouldBeFalse();

            private It _should_have_set_Int = () => Result.Int.HasBeenSet.ShouldBeTrue();

            private It _should_not_have_set_NullableInt = () => Result.NullableInt.HasBeenSet.ShouldBeFalse();
        }

        public class When_deserialising_with_missing_properties_to_an_optional_class4
        {
            public static InvalidCastException Excecption;

            private Because _of = () =>
            {
                try
                {
                    JsonConvert.DeserializeObject<OptionalClass>(Json.Test4, GetDefaultSettings());
                }
                catch (InvalidCastException ex)
                {
                    Excecption = ex;
                }
            };

            private It _should_have_thrown_an_invalid_cast_exception = () => Excecption.ShouldNotBeNull();


        }
    }
}
