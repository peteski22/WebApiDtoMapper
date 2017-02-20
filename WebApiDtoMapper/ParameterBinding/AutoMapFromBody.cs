namespace WebApi.ParameterBinding
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Metadata;
    using Newtonsoft.Json;
    using WebApiDtoMapper;

    public class MapFromBodyParameterBinding : HttpParameterBinding
    {
        private Type _type;

        public MapFromBodyParameterBinding(HttpParameterDescriptor parameter, Type type) : base(parameter)
        {
            _type = type;
        }

        public override bool WillReadBody
        {
            get { return true; }
        }

        public override async Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var mapper = (IMapper)actionContext.RequestContext.Configuration.DependencyResolver.GetService(typeof(IMapper));
            var content = await actionContext.Request.Content.ReadAsStringAsync();
            SetValue(actionContext, mapper.Map(JsonConvert.DeserializeObject(content, _type), _type, Descriptor.ParameterType));
        }
    }

    public class FromBodyMapAttribute : ParameterBindingAttribute
    {
        private Type _type;

        public FromBodyMapAttribute(Type type)
        {
            _type = type;
        }

        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            return new MapFromBodyParameterBinding(parameter, _type);
        }
    }
}