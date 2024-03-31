using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Data;

namespace AspMvcModelBindingApp.Infrastructure
{
    public class DateTimeModelBinder : IModelBinder
    {
        IModelBinder backBinder;

        public DateTimeModelBinder(IModelBinder binder)
        {
            backBinder = binder;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var date = bindingContext.ValueProvider.GetValue("date");
            var time = bindingContext.ValueProvider.GetValue("time");

            if (date == ValueProviderResult.None || time == ValueProviderResult.None)
                return backBinder.BindModelAsync(bindingContext);

            DateTime.TryParse(date.FirstValue, out var dateValue);
            DateTime.TryParse(time.FirstValue, out var timeValue);

            var result = new DateTime(dateValue.Year,
                dateValue.Month,
                dateValue.Day,
                timeValue.Hour,
                timeValue.Minute,
                timeValue.Second);

            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
}
