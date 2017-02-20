namespace WebApiDtoMapper.ModelBinders
{
    using System.Web.Http.Controllers;
    using System.Web.Http.ModelBinding;

    public class AutoMapModelBinder<TSource, TDest> : IModelBinder
        where TSource: class where TDest: class
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(TDest))
            {
                return false;
            }

            var val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (val == null)
            {
                return false;
            }

            string key = val.RawValue as string;
            if (key == null)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Wrong value type");
                return false;
            }

            TDest result = null;
            if (true)
            {
                bindingContext.Model = result;
                return true;
            }

            // TODO: Unreachable
            bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Cannot convert value to Location");
            return false;
        }
    }
}