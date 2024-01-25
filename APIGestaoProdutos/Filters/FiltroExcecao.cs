using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace APIGestaoProdutos.Application.Filters
{
    public class FiltroExcecao : IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            if(context.Exception != null)
            {

                context.HttpContext.Response.StatusCode = 400;

                await context.HttpContext.Response.WriteAsJsonAsync(new { Erro = context.Exception.Message });
                await context.HttpContext.Response.CompleteAsync();
                
            }
        }
    }
}
