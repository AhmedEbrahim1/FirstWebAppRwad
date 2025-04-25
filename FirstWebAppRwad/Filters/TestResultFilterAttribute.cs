using Microsoft.AspNetCore.Mvc.Filters;

namespace FirstWebAppRwad.Filters
{
    public class TestResultFilterAttribute : Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
