using System;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.WindowsServer.TelemetryChannel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;


namespace CommonLibrary.Logging
{
    public static class myILoggerProvider
    {
        public static IServiceCollection Congfigure(IServiceCollection services, string appInsightsKey,　string logLevel)
        {
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddApplicationInsights(appInsightsKey);
                switch (logLevel)
                {
                    case "Information":
                        loggingBuilder.AddFilter<Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider>("", LogLevel.Information);
                        break;
                    case "Warning":
                        loggingBuilder.AddFilter<Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider>("", LogLevel.Warning);
                        break;
                    case "Error":
                        loggingBuilder.AddFilter<Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider>("", LogLevel.Error);
                        break;
                    case "Debug":
                        loggingBuilder.AddFilter<Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider>("", LogLevel.Debug);
                        break;
                }
                loggingBuilder.AddConsole();
            });

            return services;
        }

        public static IFunctionsHostBuilder Congfigure(IFunctionsHostBuilder builder, string appInsightsKey, string logLevel)
        {
            builder.Services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddApplicationInsights(appInsightsKey);
                switch (logLevel)
                {
                    case "Information":
                        loggingBuilder.AddFilter<Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider>("", LogLevel.Information);
                        break;
                    case "Warning":
                        loggingBuilder.AddFilter<Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider>("", LogLevel.Warning);
                        break;
                    case "Error":
                        loggingBuilder.AddFilter<Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider>("", LogLevel.Error);
                        break;
                    case "Debug":
                        loggingBuilder.AddFilter<Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider>("", LogLevel.Debug);
                        break;
                }
                loggingBuilder.AddConsole();
            });

            return builder;
        }

    }
}
