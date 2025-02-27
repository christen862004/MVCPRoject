using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MVCPRoject.Filters
{
    public class HandelErrorAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ViewResult result = new ViewResult();
            result.ViewName = "Error";
           // result.ViewData"MEssage"]= context.Exception.Message; 
            
            //ContentResult result = new ContentResult();
            //result.Content = context.Exception.Message;// "exception throw";
            context.Result = result;
        }
    }
}
