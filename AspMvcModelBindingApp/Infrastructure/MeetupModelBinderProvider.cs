using Microsoft.AspNetCore.Mvc.ModelBinding;
using AspMvcModelBindingApp.Models;

namespace AspMvcModelBindingApp.Infrastructure
{
    public class MeetupModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType == typeof(Meetup) ? new MeetupModelBinder() : null;
        }
    }
}
