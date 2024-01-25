using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APIGestaoProdutos.Application.Filters
{
    public class FiltroValidacao : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
    
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var mensagens = context.ModelState.
                    SelectMany(ms => ms.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                context.Result = new BadRequestObjectResult(mensagens);
            }
        }
    }
}
