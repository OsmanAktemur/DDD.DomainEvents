using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDD.DomainEvents.Abstractions
{
    public interface IEventDispatcher
    {
        Task DispatchEventAsync<T>(params T[] events) where T : IDomainEvent;
    }
}
