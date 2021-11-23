using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using TradingEngineServer.Core.Configuration;

namespace TradingEngineServer.Core
{
    public sealed class TradingEngineHostBuilder
    {
        public static IHost BuildTradingEngineServer()
            => Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                // Start with Configuration
                services.AddOptions();
                services.Configure<TradingEngineServerConfiguration>(context.Configuration.GetSection(nameof(TradingEngineServerConfiguration)));

                // Add Singleton Object
                services.AddSingleton<ITradingEngineServer, TradingEngineServer>();

                // Add hosted service
                services.AddHostedService<TradingEngineServer>();
            }).Build();
    }
}
