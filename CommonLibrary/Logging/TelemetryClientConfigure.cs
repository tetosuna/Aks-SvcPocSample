using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.WindowsServer.TelemetryChannel;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace CommonLibrary.Logging
{
    public static class TelemetryClientConfigure
    {
        //public ApplicationInsightsServiceOptions aiOptions;

        /*
         TelemetryClientConfigure(string instrumentationKey)
        {
            aiOptions = new ApplicationInsightsServiceOptions();
            aiOptions.InstrumentationKey = instrumentationKey;
            setTelemetryClientOptions();
        }
        */

        public static ApplicationInsightsServiceOptions ConfigureServiceOptions(string instrumentationKey)
        {
            var aiOptions = new ApplicationInsightsServiceOptions();
            aiOptions.InstrumentationKey = instrumentationKey;
            setTelemetryClientOptions(aiOptions, instrumentationKey);
            return aiOptions;
        }


        public static IServiceCollection ConfigureServerTelemetryChannel(IServiceCollection services, string appInsightsKey)
        {
            services.AddSingleton(typeof(ITelemetryChannel), new ServerTelemetryChannel() { StorageFolder = "./" });
            var aiOptions = new ApplicationInsightsServiceOptions();
            services.AddApplicationInsightsTelemetry(setTelemetryClientOptions(aiOptions, appInsightsKey));
            return services;
        }

        public static IServiceCollection ConfigureInMemoryTelemetryChannel(IServiceCollection services, string appInsightsKey)
        {
            services.AddSingleton(typeof(ITelemetryChannel), new InMemoryChannel() { MaxTelemetryBufferCapacity = 19898 });
            var aiOptions = new ApplicationInsightsServiceOptions();
            services.AddApplicationInsightsTelemetry(setTelemetryClientOptions(aiOptions, appInsightsKey));
            return services;
        }

        public static IFunctionsHostBuilder ConfigureFunctionsServerTelemetryChannel(IFunctionsHostBuilder builder, string appInsightsKey)
        {
            builder.Services.AddSingleton(typeof(ITelemetryChannel), new ServerTelemetryChannel() { StorageFolder = "./" });
            var aiOptions = new ApplicationInsightsServiceOptions();
            builder.Services.AddApplicationInsightsTelemetry(setTelemetryClientOptions(aiOptions, appInsightsKey));
            return builder;
        }

        public static IFunctionsHostBuilder ConfigureFunctionsInMemoryTelemetryChannel(IFunctionsHostBuilder builder, string appInsightsKey)
        {
            builder.Services.AddSingleton(typeof(ITelemetryChannel), new InMemoryChannel() { MaxTelemetryBufferCapacity = 19898 });
            var aiOptions = new ApplicationInsightsServiceOptions();
            builder.Services.AddApplicationInsightsTelemetry(setTelemetryClientOptions(aiOptions, appInsightsKey));
            return builder;
        }

        private static ApplicationInsightsServiceOptions setTelemetryClientOptions(ApplicationInsightsServiceOptions aiOptions, string appInsightsKey)
        {
            aiOptions.InstrumentationKey = appInsightsKey;

            //aiOptions.InstrumentationKey = _configuration.GetValue<string>("ApplicationInsights_InstrumentationKey");

            // Disables adaptive sampling. 
            aiOptions.EnableAdaptiveSampling = false;

            // Collects Requests Telemetry
            aiOptions.EnableRequestTrackingTelemetryModule = true;
            // よくわからんけど有効
            aiOptions.EnableEventCounterCollectionModule = true;
            // Collects Depdndency Telemetry
            aiOptions.EnableDependencyTrackingTelemetryModule = true;
            // Disables QuickPulse (Live Metrics stream).
            aiOptions.EnableQuickPulseMetricStream = false;

            return aiOptions;
        }
    }
}