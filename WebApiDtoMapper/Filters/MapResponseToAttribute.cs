namespace WebApiDtoMapper.Filters
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using AutoMapper;

    //[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class MapResponseToAttribute : ActionFilterAttribute
    {
        private Type _type;

        public MapResponseToAttribute(Type type)
        {
            _type = type;
        }

        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            var status = context.Response.StatusCode;

            if (status != HttpStatusCode.OK)
            {
                return;
            }

            object content;

            if (!context.Response.TryGetContentValue(out content))
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

            var mapper = (IMapper)context.ActionContext.RequestContext.Configuration.DependencyResolver.GetService(typeof(IMapper));
            var result = mapper.Map(content, content.GetType(), _type);
            context.Response = context.Request.CreateResponse(status, result);
        }
    }
}