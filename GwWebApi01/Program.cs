using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Threading;
using Microsoft.AspNetCore.Server.Kestrel.Core;
//using Microsoft.Extensions.DependencyInjection;
using CommonLibrary;

namespace GwWebApi01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Set minimun woker threads and minimum IO threads.
            ThreadPool.SetMinThreads(100, 100);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                /*
                 *  Use Configuration Provider
                .ConfigureServices((context, services) =>
                {
                        services.Configure<KestrelServerOptions>(
                            context.Configuration.GetSection("Kestrel"));
                })
                */
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //
                    // Setup Kestrel Server Configuration
                    // NOTE: https://docs.microsoft.com/ja-jp/aspnet/core/fundamentals/servers/kestrel?view=aspnetcore-3.1
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        // Set properties and call methods on options
                        // 接続数は制限いらないかも。
                        serverOptions.Limits.MaxConcurrentConnections = 5000;
                        serverOptions.Limits.MaxConcurrentUpgradedConnections = 5000;
                        serverOptions.DisableStringReuse = false;
                        serverOptions.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(60);
                        serverOptions.Limits.RequestHeadersTimeout = TimeSpan.FromSeconds(20);
                    }).
                    UseStartup<Startup>();
                });
    }
}
