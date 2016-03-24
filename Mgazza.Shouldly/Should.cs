using Mgazza.Optional;

namespace Shouldly
{
    public static class Should
    {
        public static void ShouldBe<T>(this Optional<T> actual, T expected)
        {
            actual.Value.ShouldBe(expected);
        }
    }
}