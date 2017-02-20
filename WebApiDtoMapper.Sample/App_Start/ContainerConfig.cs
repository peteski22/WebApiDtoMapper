namespace WebApiDtoMapper.Sample.App_Start
{
    using System.Web.Http;
    using Autofac;
    using Autofac.Integration.WebApi;

    public class ContainerConfig
    {
        public static void RegisterContainer(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers();
            builder.RegisterType<Mapper>().As<IMapper>();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());
        }
    }
}