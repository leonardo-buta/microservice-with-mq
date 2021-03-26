using Microservice.MQ.Service.Domain.Interfaces;
using Microservice.MQ.Service.Domain.RabbitMQ;
using Microservice.MQ.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microservice.MQ.CrossCut
{
    public class NativeDI
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Configuration
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", false, true);
            var configuration = builder.Build();
            var rabbitConfig = configuration.GetSection("RabbitMq");

            services.Configure<RabbitMqConfiguration>(options => rabbitConfig.Bind(options));

            // Services
            services.AddTransient<IMessagePublishService, MessagePublishService>();

            // Background Services
            new HostBuilder().ConfigureServices((hostContext, services) =>
            {
                services.Configure<RabbitMqConfiguration>(options => rabbitConfig.Bind(options));
                services.AddHostedService<MessageConsumeService>();
            }).RunConsoleAsync();
        }
    }
}
