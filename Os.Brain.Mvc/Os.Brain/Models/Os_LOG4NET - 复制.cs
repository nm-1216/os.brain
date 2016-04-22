using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Logging;
using Os.Brain.Controllers;
using System;
using System.Threading.Tasks;

namespace Os.Brain.Models
{
    public static class CustomMiddlewareName
    {
        public static IApplicationBuilder UseMiddlewareName(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyMiddlewareName>();
        }
    }

    public class MyMiddlewareName
    {
        RequestDelegate _next;

        public MyMiddlewareName(RequestDelegate next)
        {
            _next = next;// 接收传入的RequestDelegate实例
        }



        public async Task Invoke(HttpContext context)
        {
            // 处理代码，如处理context.Request中的内容

            Console.WriteLine("Middleware开始处理");

            await _next(context);

            Console.WriteLine("Middleware结束处理");

            // 处理代码，如处理context.Response中的内容
        }


    }
}