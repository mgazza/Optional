using AutoMapper;
using Machine.Specifications;
using Shouldly;


namespace Mgazza.Optional.Tests.AutoMapper
{
    public class OptionalSpec
    {
        public class OptionalClass
        {
            public Optional<string> String { get; set; }

            public Optional<int> Int { get; set; }

            public Optional<int?> NullableInt { get; set; }
        }

        public class ConcreteClass
        {
            public string String { get; set; }

            public int Int { get; set; }

            public int? NullableInt { get; set; }
        }

        public class When_mapping_between_classes_with_optionals_with_everything_set
        {
            private static readonly OptionalClass Source = new OptionalClass
            {
                Int = 10,
                NullableInt = null,
                String = "string"

            };

            private static readonly OptionalClass Destination = new OptionalClass();

            private static IMapper _mapper;

            private Establish _context = () =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<OptionalClass, OptionalClass>().OnlyOptionals();
                });

                
                _mapper = config.CreateMapper();

            };

            private Because _of = () =>
            {
                _mapper.Map(Source, Destination);
            };

            private It _should_have_set_String_on_destination = () => Destination.String.HasBeenSet.ShouldBeTrue();
            private It _should_have_set_Int_on_destination = () => Destination.Int.HasBeenSet.ShouldBeTrue();
            private It _should_have_set_NullableInt_on_destination = () => Destination.NullableInt.HasBeenSet.ShouldBeTrue();

        }
        public class When_mapping_between_classes_with_optionals_with_nothing_set
        {
            private static readonly OptionalClass Source = new OptionalClass();
            private static readonly OptionalClass Destination = new OptionalClass();

            private static IMapper _mapper;

            private Establish _context = () =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<OptionalClass, OptionalClass>().OnlyOptionals();
                });


                _mapper = config.CreateMapper();

            };

            private Because _of = () =>
            {
                _mapper.Map(Source, Destination);
            };

            private It _should_not_have_set_String_on_destination = () => Destination.String.HasBeenSet.ShouldBeFalse();
            private It _should_not_have_set_Int_on_destination = () => Destination.Int.HasBeenSet.ShouldBeFalse();
            private It _should_not_have_set_NullableInt_on_destination = () => Destination.NullableInt.HasBeenSet.ShouldBeFalse();

        }

        public class When_mapping_between_classes_with_optionals_with_some_set
        {
            private static readonly OptionalClass Source = new OptionalClass
            {
                NullableInt = null,
                String = "Foo"
            };

            private static readonly OptionalClass Destination = new OptionalClass
            {
                Int = 100,
                NullableInt = 200,
                String = "Bar"
            };

            private static IMapper _mapper;

            private Establish _context = () =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<OptionalClass, OptionalClass>().OnlyOptionals();
                });


                _mapper = config.CreateMapper();

            };

            private Because _of = () =>
            {
                _mapper.Map(Source, Destination);
            };

            private It _should_have_mapped_String_on_destination = () => Destination.String.ShouldBe(Source.String);

            private It _should_not_have_mapped_Int_on_destination = () => Destination.Int.ShouldNotBe(Source.Int);

            private It _should_have_left_Int_unchanged_and_set_on_destination = () =>
            {
                Destination.Int.ShouldNotBeSameAs(Source.Int);
                Destination.Int.HasBeenSet.ShouldBeTrue();
            };

            private It _should_have_mapped_NullableInt_on_destination = () => Destination.NullableInt.ShouldBe(Source.NullableInt);

        }


        public class When_mapping_between_optional_and_others
        {
            private static readonly OptionalClass Source = new OptionalClass
            {
                String = null
            };

            private static readonly ConcreteClass Destination = new ConcreteClass
            {
                Int = 200,
                NullableInt = 500,
                String = "Foo"
            };

            private static IMapper _mapper;

            private Establish _context = () =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<OptionalClass, ConcreteClass>().OnlyOptionals();
                });


                _mapper = config.CreateMapper();

            };

            private Because _of = () =>
            {
                _mapper.Map(Source, Destination);
            };

            private It _should_have_set_String_on_destination = () => Destination.String.ShouldBe(null);
            private It _should_not_have_set_Int_on_destination = () => Destination.Int.ShouldBe(200);
            private It _should_not_have_set_NullableInt_on_destination = () => Destination.NullableInt.ShouldBe(500);

        }
    }
}


