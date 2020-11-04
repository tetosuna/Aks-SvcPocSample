using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.ApplicationInsights.Channel;
using CommonLibrary.Logging;
using Microsoft.Extensions.DependencyInjection.Extensions;
/* Server Telemetry Channel用
using Microsoft.ApplicationInsights.WindowsServer.TelemetryChannel;
using Microsoft.ApplicationInsights.Extensibility.Implementation.Tracing;
using Microsoft.ApplicationInsights.Extensibility;
*/

[assembly: FunctionsStartup(typeof(AksPocSampleFunctions.Startup))]

namespace AksPocSampleFunctions
{
    public class Startup : FunctionsStartup
    {

        //FunctionsStartup
        //NOTE: https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-dotnet-dependency-injection
        //NOTE: https://blog.shibayan.jp/entry/20200823/1598186591
        //NOTE: https://stackoverflow.com/questions/57564396/how-do-i-mix-custom-parameter-binding-with-dependency-injection-in-azure-functio

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            FunctionsHostBuilderContext context = builder.GetContext();
            builder.ConfigurationBuilder
                .SetBasePath(context.ApplicationRootPath)
                .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            IWebJobsBuilder hBuilder = builder.Services.AddWebJobs(x => { return; });
            hBuilder.AddKafka();

            string appInsightsKey = builder.GetContext().Configuration.GetValue<string>("ApplicationInsights_InstrumentationKey");
            string logLevel = builder.GetContext().Configuration.GetValue<string>("Log_Level");

            /* ILoggerの利用。Functionsでは成功していない。
            builder.Services.AddLogging(loggingBuilder =>
            {
                //loggingBuilder.ClearProviders();
                loggingBuilder.AddApplicationInsights(appInsightsKey);
                loggingBuilder.AddConsole();                
                loggingBuilder.AddFilter<Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider>("Category", LogLevel.Information);
            }).BuildServiceProvider();
            */

            /*
            Server TelemetryChannelで実装
            builder.Services.AddSingleton(typeof(ITelemetryChannel),
                                new ServerTelemetryChannel() { StorageFolder = "./" });
            */

            // InMemoryChannelで実装
            builder.Services.AddSingleton(typeof(ITelemetryChannel), new InMemoryChannel() { MaxTelemetryBufferCapacity = 19898 });


            var aiOptions = TelemetryClientConfigure.ConfigureServiceOptions(appInsightsKey);

            /* IFunctionsConfigurationBuilderを別クラスのメソッドで初期化する。
            //builder = TelemetryClientConfigure.ConfigureFunctionsInMemoryTelemetryChannel(builder, appInsightsKey);
            //builder = myILoggerProvider.Congfigure(builder, appInsightsKey, logLevel);
            */

            builder.Services.AddApplicationInsightsTelemetry(aiOptions);
            builder.Services.AddSingleton<Functions>();
            //builder.Services.AddApplicationInsightsTelemetryWorkerService(telemetryConfigutaion);
            builder.Services.BuildServiceProvider(true);
        }
    }
}
