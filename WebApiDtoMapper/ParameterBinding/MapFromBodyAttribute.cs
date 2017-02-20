using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using WebApi.ParameterBinding;

namespace WebApiDtoMapper.ParameterBinding
{
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