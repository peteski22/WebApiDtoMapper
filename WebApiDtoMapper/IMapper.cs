namespace WebApiDtoMapper
{
    using System;

    public interface IMapper
    {
        object Map(object source, Type sourceType, Type destType);
    }
}