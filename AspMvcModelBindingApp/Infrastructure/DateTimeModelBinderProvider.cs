using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace AspMvcModelBindingApp.Infrastructure
{
    public class DateTimeModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            ILoggerFactory loggerFactory = context.Services.GetService<ILoggerFactory>();
            IModelBinder binder = new DateTimeModelBinder(
                new SimpleTypeModelBinder(typeof(DateTime), loggerFactory)
                );
            return context.Metadata.ModelType == typeof(DateTime) ? binder : null;
        }
    }
}
