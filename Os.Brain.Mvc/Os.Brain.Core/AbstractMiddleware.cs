
namespace Os.Brain.Core
{
    using System.Threading.Tasks;
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Http;
    public static class ExtendApplicationBuilder
    {
        //this 关键字扩展
        public static IApplicationBuilder UseDemoMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<DemoMiddleware>();
        }
    }

    public abstract class AbstractMiddleware
    {
        protected RequestDelegate Next { get; set; }

        protected AbstractMiddleware(RequestDelegate next)
        {
            this.Next = next;
        }

        public abstract Task Invoke(HttpContext context);
    }
    
    public class DemoMiddleware : AbstractMiddleware
    {
        public DemoMiddleware(RequestDelegate next) : base(next)
        {
        }

        public async override Task Invoke(HttpContext context)
        {
            //Console.WriteLine("DemoMiddleware Start.");
            await Next.Invoke(context);
            //Console.WriteLine("DemoMiddleware End.");
        }
    }

    //注册方式
    // 1、app.Use(next => new DemoMiddleware(next).Invoke);
    // 2、app.UseMiddleware<DemoMiddleware>();
    // 3、app.UseDemoMiddleware();
    // 第三种方法必须扩展IApplicationBuilder

    // Eg:
    //public static IApplicationBuilder UseDemoMiddleware(this IApplicationBuilder app)
    //{
    //    return app.UseMiddleware<TimeRecorderMiddleware>();
    //}
    
}
