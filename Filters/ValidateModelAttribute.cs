using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace sample_action_filter.Filters {
  public class ValidateModelAttribute : IActionFilter {
    public void OnActionExecuted (ActionExecutedContext context) {
      throw new System.NotImplementedException ();
    }

    public void OnActionExecuting (ActionExecutingContext context) {
      if (!context.ModelState.IsValid) {
        var errorMessages = context.ModelState.Values.SelectMany (value => value.Errors).Select (value => value.ErrorMessage);
        var response = new MyResponse<string> ();
        response.ErrorsMessage = errorMessages.ToList ();
        context.Result = new BadRequestObjectResult (response);
      }
    }
  }
}