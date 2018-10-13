using DDD.DomainEvents.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.DomainEvents.DomainEventHandler
{
    public class OrderCreatedHandler : IEventHandler<OrderCreatedDomainEvent>
    {
        public async Task HandleAsync(OrderCreatedDomainEvent @event)
        {
            Thread.Sleep(5000);
            Console.WriteLine($"Order created event handled. OrderId:{@event.OrderId}");
            await File.WriteAllTextAsync("a.txt", "testteste");
        }
    }
}
