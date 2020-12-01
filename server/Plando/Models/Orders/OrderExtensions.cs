using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Plando.Common;

namespace Plando.Models.Orders
{
    public static class OrdersExtensions
    {
        // context.GetOrder(id)
        public static async Task<Order> GetOrder(this ApplicationContext context, int id)
        {
            var orderCreatedEvent = await context.OrderCreatedEvents
                .FirstOrDefaultAsync(x => x.Id == id) as IAggregator<Order>;

            if (orderCreatedEvent is null)
                return null;

            var orderPassedEvent = await context.OrderPassedEvents
                .FirstOrDefaultAsync(x => x.OrderId == id) as IAggregator<Order>;

            var orderFinishedEvent = await context.OrderFinishedEvents
                .FirstOrDefaultAsync(x => x.OrderId == id) as IAggregator<Order>;

            var serviceAddedEvents = context.ServiceAddedEvents
                .Where(x => x.OrderId == id)
                .Select(x => x as IAggregator<Order>)
                .AsEnumerable();

            var serviceCompletedEvents = context.ServiceCompletedEvents
                .Where(x => x.OrderId == id)
                .Select(x => x as IAggregator<Order>)
                .AsEnumerable();

            var serviceRemovedEvents = context.ServiceAddedEvents
                .Where(x => x.OrderId == id)
                .Select(x => x as IAggregator<Order>)
                .AsEnumerable();

            var aggregates = new List<IAggregator<Order>>();

            aggregates.Add(orderCreatedEvent);
            aggregates.Add(orderPassedEvent);
            aggregates.Add(orderFinishedEvent);
            aggregates.AddRange(serviceAddedEvents);
            aggregates.AddRange(serviceRemovedEvents);
            aggregates.AddRange(serviceCompletedEvents);

            return aggregates.Aggregate();
        }
    }
}