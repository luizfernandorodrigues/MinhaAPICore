using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MinhaAPICore
{
    public class MeuMiddleware
    {
        private readonly RequestDelegate _next;

        public MeuMiddleware(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Inicio do Middleware");

            await _next.Invoke(context);

            Console.WriteLine("Chamada final do Middleware");
        }
    }

    // classe de extension para retornar o meu midleware criado e manter o padrão do asp. core 
    public static  class ExtensionMeuMiddleware
    {
        // exemplo de utilização app.UseMeuMiddleware(); na classe Startup.cs
        public static IApplicationBuilder UseMeuMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MeuMiddleware>();
        }
    }
}
