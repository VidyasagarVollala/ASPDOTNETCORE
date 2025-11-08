using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ModelValidationExample.CustomeModelBinderClass
{
	public class PersonModelBinder : IModelBinder
	{
		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			throw new NotImplementedException();
		}
	}
}
