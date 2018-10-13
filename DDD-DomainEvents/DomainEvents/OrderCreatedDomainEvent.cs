using DDD.DomainEvents.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.DomainEvents
{
    public class OrderCreatedDomainEvent : IDomainEvent
    {
        public string OrderId { get; set; }
    }
}
