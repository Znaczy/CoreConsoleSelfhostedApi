using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ServiceStack;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CoreConsoleSelfhostedApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>()
            .UseUrls(Environment.GetEnvironmentVariable("ASPNETCORE_URLS") ?? "http://localhost:5000/")
            .Build();

            host.Run();

            Console.WriteLine("App is running");
        }
        public class Startup
        {
            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                app.UseServiceStack(new AppHost());

                app.Run(context =>
                {
                    context.Response.Redirect("/metadata");
                    return Task.FromResult(0);
                });
            }
        }

        public class AppHost : AppHostBase
        {
            public AppHost()
                : base("MyApp", typeof(MyService).Assembly) { }

            public override void Configure(Container container)
            {
            }
        }
    }
}