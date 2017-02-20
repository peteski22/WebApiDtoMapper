namespace WebApi.ParameterBinding
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Metadata;
    using AutoMapper;
    using Newtonsoft.Json;
    using WebApiDtoMapper.Models;

    public class MapFromBodyParameterBinding : HttpParameterBinding
    {
        private Type _type;

        public MapFromBodyParameterBinding(HttpParameterDescriptor parameter, Type type) : base(parameter)
        {
            _type = type;
            Mapper.Initialize(x => x.CreateMap<HelloDto, Hello>());
        }

        public override bool WillReadBody
        {
            get { return true; }
        }

        public override async Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var content = await actionContext.Request.Content.ReadAsStringAsync();
            SetValue(actionContext, Mapper.Map(JsonConvert.DeserializeObject(content, _type), _type, Descriptor.ParameterType));
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