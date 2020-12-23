using System.Collections.Generic;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using Plando.Common;
using Plando.Models.Users;
using Plando.Models.Orders;
using Microsoft.EntityFrameworkCore;

using static Plando.Common.TypedException;

using Plando.Models;

namespace Plando.Queries.Orders
{
    public class GetAllOrders : PaginatedQuery, IQuery<IEnumerable<Order>>
    {
        public GetAllOrders(int userId)
            => UserId = userId;
        public int UserId { get; set; }
    }

    public class GetAllOrdersHandler : HandlerWithApplicationContext, IQueryHandler<GetAllOrders, IEnumerable<Order>>
    {
        public GetAllOrdersHandler(ApplicationContext context) : base(context) { }
        public async Task<IEnumerable<Order>> HandleAsync(GetAllOrders query)
        {
            /*return await _context.GetOrdersAsync(
                query.Page,
                query.PerPage);*/

            var user = await _context.Users
                .AsNoTracking()
                .Include(x => x.Identity)
                .SingleOrDefaultAsync(x => x.Id == query.UserId);

            var orders = await _context.GetOrdersAsync(
                query.Page,
                query.PerPage);

            if (user.Id == 1)
            {
                return orders;
            }
            if (user.Identity.Role == UserRole.Manager)
            {
                List<Order> result = new List<Order>();
                foreach (Order order in orders)
                {
                    if (order.LaundryId == user.LaundryId)
                    {
                        result.Add(order);
                    }
                }
                return result.ToArray();
            }
            if (user.Identity.Role == UserRole.Client)
            {
                List<Order> result = new List<Order>();
                foreach (Order order in orders)
                {
                    if (order.ClientId == user.Id)
                    {
                        result.Add(order);
                    }
                }
                return result.ToArray();

            }
            else throw BusinessLogicException($"Cannot return order {query.UserId} to user {user.Id}");




        }
    }
}