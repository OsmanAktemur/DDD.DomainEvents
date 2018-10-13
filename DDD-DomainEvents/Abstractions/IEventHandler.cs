using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDD.DomainEvents.Abstractions
{
    interface IEventHandler<in T> where T : IDomainEvent
    {
        Task HandleAsync(T @event);
    }
}
