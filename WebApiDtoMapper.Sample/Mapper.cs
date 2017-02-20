namespace WebApiDtoMapper
{
    using System;

    public class Mapper : IMapper
    {
        static Mapper()
        {
            // TODO: Inject this
            //AutoMapper.Mapper.Initialize(x => x.CreateMap<Hello, HelloDto>().ReverseMap());
        }

        public object Map(object source, Type sourceType, Type destType)
        {
            return AutoMapper.Mapper.Map(source, sourceType, destType);
        }
    }
}