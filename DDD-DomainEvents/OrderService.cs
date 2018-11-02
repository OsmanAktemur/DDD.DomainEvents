using DDD.DomainEvents.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDD.DomainEvents
{
    public class OrderService
    {
        private readonly IEventDispatcher _eventDispatcher;
        public OrderService(IEventDispatcher _eventDispatcher)
        {
            this._eventDispatcher = _eventDispatcher;
        }

        public  void CreateOrder(string order)
        {
            Console.WriteLine("Order Creating...");

            //do smth.
            Console.WriteLine("Order Created...");

            this._eventDispatcher.DispatchEventAsync(new OrderCreatedDomainEvent()
            {
                OrderId = order
            });


			
            Console.WriteLine("Doing some other stuffs...")
        }
    }
}
