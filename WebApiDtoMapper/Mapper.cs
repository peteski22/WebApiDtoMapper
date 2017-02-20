using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiDtoMapper.Models;

namespace WebApiDtoMapper
{
    public class Mapper : IMapper
    {
        static Mapper()
        {
            AutoMapper.Mapper.Initialize(x => x.CreateMap<Hello, HelloDto>().ReverseMap());
        }

        public object Map(object source, Type sourceType, Type destType)
        {
            return AutoMapper.Mapper.Map(source, sourceType, destType);
        }
    }
}