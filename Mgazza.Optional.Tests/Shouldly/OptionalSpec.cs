using Machine.Specifications;
using Shouldly;

namespace Mgazza.Optional.Tests.Shouldly
{
    public class OptionalSpec
    {

        private static Optional<string> _stringOptional = "string";

        It _should_use_shoudly_extension_and_work = () => _stringOptional.ShouldBe("string");
    }
}
