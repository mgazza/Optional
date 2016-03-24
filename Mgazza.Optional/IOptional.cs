namespace Mgazza.Optional
{

    public interface IOptional
    {
        bool HasBeenSet { get; }

        object Value { get; }
    }
}
