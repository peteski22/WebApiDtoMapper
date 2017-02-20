using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace WebApiDtoMapper.App_Start
{
    public class ContainerConfig
    {
        public static void RegisterContainer(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers();
            builder.RegisterType<Thing>().As<IThing>();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());
        }
    }

    public interface IThing
    {
    }

    public interface Thing
    {
    }
}