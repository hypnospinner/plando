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
        public static async Task<Order> GetOrderAsync(this ApplicationContext context, int id)
        {
            var orderCreatedEvent = await context.OrderCreatedEvents
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id) as IAggregator<Order>;

            if (orderCreatedEvent is null)
                return null;

            var orderPassedEvent = await context.OrderPassedEvents
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.OrderId == id) as IAggregator<Order>;

            var orderFinishedEvent = await context.OrderFinishedEvents
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.OrderId == id) as IAggregator<Order>;

            var serviceAddedEvents = context.ServiceAddedEvents
                .AsNoTracking()
                .Where(x => x.OrderId == id)
                .Select(x => x as IAggregator<Order>)
                .AsEnumerable();

            var serviceCompletedEvents = context.ServiceCompletedEvents
                .AsNoTracking()
                .Where(x => x.OrderId == id)
                .Select(x => x as IAggregator<Order>)
                .AsEnumerable();

            var serviceRemovedEvents = context.ServiceAddedEvents
                .AsNoTracking()
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

        public static async Task<IEnumerable<Order>> GetOrdersAsync(this ApplicationContext context, int page = 0, int perPage = 20)
        {
            var orderCreatedEvents = await context.OrderCreatedEvents
                .AsNoTracking()
                .OrderBy(x => x.CreatedAt)
                .Skip(page * perPage)
                .Take(perPage)
                .ToListAsync();

            var tasks = orderCreatedEvents
                .Select(x => context.GetOrderAsync(x.Id))
                .ToArray();

            Task.WaitAll(tasks);

            return tasks.Select(x => x.Result);
        }
    }
}