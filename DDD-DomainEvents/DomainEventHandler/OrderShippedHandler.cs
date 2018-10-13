using DDD.DomainEvents.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.DomainEvents.DomainEventHandler
{
    public class OrderShippedHandler : IEventHandler<OrderShippedDomainEvent>
    {
        public async Task HandleAsync(OrderShippedDomainEvent @event)
        {
            Thread.Sleep(5500);
            Console.WriteLine($"Order shipped Event handled. OrderId:{@event.OrderId}");
            await File.WriteAllTextAsync("a.txt", "testteste");
        }
    }
}
