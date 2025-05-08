using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SimpleBank.Communication.Responses;
using SimpleBank.Exceptions.ExceptionsBase;
using System.Net;

namespace SimpleBank.Presentation.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is SimpleBankExceptions) HandleProjectExceptions(context);
            else HandleGenericExceptions(context);
        }

        private void HandleProjectExceptions(ExceptionContext context)
        {
            var exception = context.Exception as ErrorOnValidationException; // cast da exception
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest; // define o status 
            context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception.ErrorMessages));
        }

        private void HandleGenericExceptions(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError ; // define o status 
            context.Result = new ObjectResult(new ResponseErrorJson("Unknow error."));
        }
    }
}
    