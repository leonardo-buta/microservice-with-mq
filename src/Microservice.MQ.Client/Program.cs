using Microservice.MQ.CrossCut;
using Microservice.MQ.Service.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;

namespace Microservice.MQ.Client
{
    class Program
    {
        private static IMessagePublishService _messagePublishService;

        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            NativeDI.RegisterServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            _messagePublishService = serviceProvider.GetService<IMessagePublishService>();

            Timer timer = new Timer(Callback, null, 0, 5000);
            Console.ReadLine();
        }

        private static void Callback(object state)
        {
            var message = _messagePublishService.SendMessage("MyService", "Hello World!");
            Console.WriteLine($"[Sent] Identifier: {message.Identifier} | Content: {message.MessageContent} | Date: {DateTime.Now:dd/MM/yyyy HH:mm}");
        }
    }
}
