using WebApiDtoMapper.Sample.Models;

namespace WebApiDtoMapper.Sample.App_Start
{
    public class MapperConfig
    {
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(x => x.CreateMap<Hello, HelloDto>().ReverseMap());
        }
    }
}