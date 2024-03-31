using Microsoft.AspNetCore.Mvc.ModelBinding;
using AspMvcModelBindingApp.Models;

namespace AspMvcModelBindingApp.Infrastructure
{
    public class MeetupModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var dateValue = bindingContext.ValueProvider.GetValue("date");
            var timeValue = bindingContext.ValueProvider.GetValue("time");
            var titleValue = bindingContext.ValueProvider.GetValue("title");
            var idValue = bindingContext.ValueProvider.GetValue("id");

            var date = dateValue.FirstValue;
            var time = timeValue.FirstValue;
            var title = titleValue.FirstValue;
            var id = idValue.FirstValue;

            if (String.IsNullOrEmpty(id))
                id = Guid.NewGuid().ToString();

            if (String.IsNullOrEmpty(title))
                title = "Notitle meetup";

            DateTime.TryParse(date, out var dateParse);
            DateTime.TryParse(time, out var timeParse);

            var result = new DateTime(dateParse.Year,
                dateParse.Month,
                dateParse.Day,
                timeParse.Hour,
                timeParse.Minute,
                timeParse.Second);

            bindingContext.Result = ModelBindingResult.Success(
                new Meetup()
                {
                    Id = id,
                    Title = title,
                    Date = result
                });

            return Task.CompletedTask;
        }
    }
}
