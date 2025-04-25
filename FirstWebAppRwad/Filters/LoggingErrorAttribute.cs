using FirstWebAppRwad.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FirstWebAppRwad.Filters
{
    public class LoggingErrorAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //do some logic 
            

        }
    }
}
