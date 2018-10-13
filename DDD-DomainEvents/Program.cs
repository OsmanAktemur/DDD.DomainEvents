using DDD.DomainEvents;
using DDD.DomainEvents.Abstractions;
using DDD.DomainEvents.DomainEventHandler;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace DDD_DomainEvents
{
    class Program
    {
        static void Main(string[] args)
        {

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IEventDispatcher, EventDispatcher>();



            var type = typeof(IEventHandler<>);
            var handlers =  Assembly.GetExecutingAssembly()
                           .GetTypes()
                           .Where(t => t.GetInterfaces()
                                        .Any(i => i.IsGenericType &&
                                             i.GetGenericTypeDefinition().Equals(type)));

            foreach (var handler in handlers)
            {
                var implementedInterface = handler.GetInterfaces().FirstOrDefault(x => x.GetGenericTypeDefinition() == type);
                serviceProvider.AddSingleton(implementedInterface, handler);
            }

             var context = serviceProvider.BuildServiceProvider();

            Console.WriteLine("READY!");

            OrderService orderService = new OrderService(context.GetService<IEventDispatcher>());
            orderService.CreateOrder("31246534");

            Console.WriteLine("Program ends...");
            Console.ReadKey();
        }
    }
}
