using Mgazza.Optional;

namespace AutoMapper
{
    public static class MappingExpression
    {
        public static void OnlyOptionals<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mappingExpression)
        {
            mappingExpression.ForAllMembers(mo => mo.Condition(f =>
            {
                var opt = f.SourceValue as IOptional;
                return opt != null && opt.HasBeenSet;
            }));
        }
    }
}
