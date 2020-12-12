using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using Microsoft.EntityFrameworkCore;
using Plando.Common;
using Plando.Models.Orders;

using Plando.Models;

namespace Plando.Queries.Orders
{
    public class GetAllOrders : PaginatedQuery, IQuery<IEnumerable<Order>> { }

    public class GetAllOrdersHandler : HandlerWithApplicationContext, IQueryHandler<GetAllOrders, IEnumerable<Order>>
    {
        public GetAllOrdersHandler(ApplicationContext context) : base(context) { }
        public async Task<IEnumerable<Order>> HandleAsync(GetAllOrders query)
        {
            var orders = await _context.
            var orders = await _context.OrderCreatedEvents
                    .Skip(query.Page * query.PerPage)
                    .Take(query.PerPage)
                    .ToListAsync();



            return orders
                .Select(x => )
        }
    }
}