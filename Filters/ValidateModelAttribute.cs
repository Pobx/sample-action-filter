using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace sample_action_filter.Filters {
  public class ValidateModelAttribute : ActionFilterAttribute {
    public override void OnResultExecuting (ResultExecutingContext context) {
      if (context.ModelState.IsValid == false) {
        var errorMessages = context.ModelState.Values.SelectMany (value => value.Errors).Select (value => value.ErrorMessage);
        var response = new MyResponse<string> ();
        response.ErrorsMessage = errorMessages.ToList ();
        context.Result = new BadRequestObjectResult (response);
      }
    }
  }
}