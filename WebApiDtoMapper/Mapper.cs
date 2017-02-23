namespace WebApiDtoMapper
{
    using System;

    public class Mapper : IMapper
    {
        public object Map(object source, Type sourceType, Type destType)
        {
            return AutoMapper.Mapper.Map(source, sourceType, destType);
        }
    }
}