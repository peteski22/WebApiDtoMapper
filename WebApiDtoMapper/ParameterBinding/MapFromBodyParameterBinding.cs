namespace WebApiDtoMapper.ParameterBinding
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.Controllers;
    using System.Web.Http.Metadata;
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
            var content = await actionContext.Request.Content.ReadAsStreamAsync();
            var reader = new JsonTextReader(new StreamReader(content));
            var deserialized = actionContext.ActionDescriptor.Configuration.Formatters.JsonFormatter.CreateJsonSerializer().Deserialize(reader, _type);

            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(deserialized, new ValidationContext(deserialized), validationResults))
            {
                validationResults.ForEach(x => actionContext.ModelState.AddModelError(x.MemberNames.First(), x.ErrorMessage));
            }

            var mapper = (IMapper)actionContext.RequestContext.Configuration.DependencyResolver.GetService(typeof(IMapper));
            SetValue(actionContext, mapper.Map(deserialized, _type, Descriptor.ParameterType));
        }
    }
}