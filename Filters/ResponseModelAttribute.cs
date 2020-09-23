using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace sample_action_filter.Filters {
  public class ResponseModelAttribute : ResultFilterAttribute {
    public override void OnResultExecuting (ResultExecutingContext context) {

      var response = new MyResponse<object> ();
      response.Entities = null;

      if (!context.ModelState.IsValid) {
        var errorMessages = context.ModelState.Values.SelectMany (value => value.Errors).Select (value => value.ErrorMessage);
        response.ErrorsMessage = errorMessages.ToList ();
        context.Result = new BadRequestObjectResult (response);
      } else if (context.ModelState.IsValid && context.Result is OkObjectResult okResult) {
        response.Entities = okResult.Value;
        context.Result = new OkObjectResult (response);

      } else if (context.ModelState.IsValid && context.Result is CreatedResult createdResult) {
        response.Entities = createdResult.Value;
        context.Result = new CreatedResult ("", response);
      }

      Console.WriteLine ("Hello from ResponseModelAttribute");
    }

  }
}