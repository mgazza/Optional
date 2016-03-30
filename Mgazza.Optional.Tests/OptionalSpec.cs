using Shouldly;
using It = Machine.Specifications.It;

namespace Mgazza.Optional.Tests
{
    public class OptionalSpec
    {
        public class TestClass
        {
            public Optional<string> StringProp { get; set; }
            public Optional<int> IntProp { get; set; }
            public Optional<int?> NullableIntProp { get; set; }
        }

        public class When_using_optional_with_all_props_set
        {

            private static readonly int? NullableInt = 10;

            public static readonly TestClass TestClass = new TestClass
            {
                StringProp = "String",
                IntProp = 10,
                NullableIntProp = 10
            };

            It _should_have_StringProp_set = () => TestClass.StringProp.HasBeenSet.ShouldBeTrue();

            It _should_have_IntProp_set = () => TestClass.IntProp.HasBeenSet.ShouldBeTrue();

            It _should_have_NullableIntProp_set = () => TestClass.NullableIntProp.HasBeenSet.ShouldBeTrue();

            It _should_allow_string_to_be_compareable_to_Optional_of_type_string = () => (TestClass.StringProp=="String").ShouldBeTrue();

            It _should_allow_int_to_be_compareable_to_Optional_of_type_int = () => (TestClass.IntProp == 10).ShouldBeTrue();

            It _should_allow_nullable_int_to_be_compareable_to_Optional_of_type_nullable_int = () => (TestClass.NullableIntProp==NullableInt).ShouldBeTrue();
        }

        public class When_using_optional_with_all_props_unset
        {

            private static readonly int? NullableInt = 10;

            public static readonly TestClass TestClass = new TestClass
            {
                
            };

            It _should_have_StringProp_set = () => TestClass.StringProp.HasBeenSet.ShouldBeFalse();

            It _should_have_IntProp_set = () => TestClass.IntProp.HasBeenSet.ShouldBeFalse();

            It _should_have_NullableIntProp_set = () => TestClass.NullableIntProp.HasBeenSet.ShouldBeFalse();

            It _should_allow_string_to_be_compareable_to_Optional_of_type_string = () => (TestClass.StringProp == "String").ShouldBeFalse();

            It _should_allow_int_to_be_compareable_to_Optional_of_type_int = () => (TestClass.IntProp == 10).ShouldBeFalse();

            It _should_allow_nullable_int_to_be_compareable_to_Optional_of_type_nullable_int = () => (TestClass.NullableIntProp == NullableInt).ShouldBeFalse();
        }

        public class When_using_optional_with_all_reference_props_set_to_null
        {

            private static readonly int? NullableInt = null;

            public static readonly TestClass TestClass = new TestClass
            {
                StringProp = null,
                NullableIntProp = null
            };

            It _should_have_StringProp_set = () => TestClass.StringProp.HasBeenSet.ShouldBeTrue();

            It _should_have_IntProp_set = () => TestClass.IntProp.HasBeenSet.ShouldBeFalse();

            It _should_have_NullableIntProp_set = () => TestClass.NullableIntProp.HasBeenSet.ShouldBeTrue();

            It _should_allow_string_to_be_compareable_to_Optional_of_type_string = () => (TestClass.StringProp == null).ShouldBeTrue();

            It _should_allow_int_to_be_compareable_to_Optional_of_type_int = () => (TestClass.IntProp == 0).ShouldBeTrue();

            It _should_allow_nullable_int_to_be_compareable_to_Optional_of_type_nullable_int = () => (TestClass.NullableIntProp == NullableInt).ShouldBeTrue();
        }
    }
}
