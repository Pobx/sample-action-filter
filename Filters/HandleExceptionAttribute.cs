using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace sample_action_filter.Filters {
  public class HandleExceptionAttribute : ExceptionFilterAttribute {

    public override void OnException (ExceptionContext context) {
      var response = new MyResponse<string> ();

      response.ErrorsMessage.Add (context.Exception.Message);
      context.Result = new ObjectResult (response) {
        StatusCode = 500
      };

      context.ExceptionHandled = true;

      Console.WriteLine ("Hello from HandleExceptionAttribute");
    }
  }
}