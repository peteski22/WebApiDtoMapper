namespace WebApiDtoMapper.ParameterBinding
{
    using System;
    using System.Web.Http;
    using System.Web.Http.Controllers;

    public class MapFromBodyAttribute : ParameterBindingAttribute
    {
        private Type _type;

        public MapFromBodyAttribute(Type type)
        {
            _type = type;
        }

        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            return new MapFromBodyParameterBinding(parameter, _type);
        }
    }
}