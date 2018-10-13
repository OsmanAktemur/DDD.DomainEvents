using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DDD.DomainEvents.Abstractions
{
    public class EventDispatcher : IEventDispatcher
    {
        private IServiceProvider _serviceProvider { get; set; }

        public EventDispatcher(IServiceProvider _serviceProvider)
        {
            this._serviceProvider = _serviceProvider;
        }

        //I need to find out how to get generic handler in Autofac
        public async Task DispatchEventAsync<T>(params T[] events) where T : IDomainEvent
        {
            await Task.Run(() =>
            {
                foreach (var @event in events)
                {
                    if (@event == null)
                        throw new ArgumentNullException(nameof(@event), "Event can not be null.");

                    var eventType = @event.GetType();
                    var handlerType = typeof(IEventHandler<>).MakeGenericType(eventType);
                    object handler;
                    handler = this._serviceProvider.GetService(handlerType);

                    if (handler == null)
                        throw new ArgumentNullException(nameof(@event), "Handler can not be found.");


                      ((dynamic)handler).HandleAsync(@event);
                }
            });
        }
    }
}
