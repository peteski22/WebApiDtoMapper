namespace WebApiDtoMapper.Filters
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using AutoMapper;
    using WebApiDtoMapper.Models;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AutoMapAttribute : ActionFilterAttribute
    {
        private readonly Type _destType;

        static AutoMapAttribute()
        {
            Mapper.Initialize(x => x.CreateMap<Hello, HelloDto>());
        }

        public AutoMapAttribute(Type destType)
        {
            _destType = destType;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
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
                return;
            }

            var result = Mapper.Map(content, content.GetType(), _destType);
            context.Response = context.Request.CreateResponse(status, result);
        }
    }
}