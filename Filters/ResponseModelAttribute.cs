using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace sample_action_filter.Filters {
  public class ResponseModelAttribute : ResultFilterAttribute {
    public override void OnResultExecuting (ResultExecutingContext context) {

      var result = context.Result as ObjectResult;
      var response = new MyResponse<object> ();
      response.Entities = result?.Value;

      if (context.ModelState.IsValid && context.Result is OkObjectResult) {
        context.Result = new OkObjectResult (response);
      } else if (context.ModelState.IsValid && context.Result is CreatedResult) {
        context.Result = new CreatedResult ("", response);
      }
    }

  }
}