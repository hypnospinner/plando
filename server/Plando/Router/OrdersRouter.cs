using System.Collections.Generic;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using Plando.Commands.Orders;
using Plando.DTOs;
using Plando.Models.Orders;
using Plando.Queries.Orders;

namespace Plando.Router
{
    internal static class OrdersRouter
    {
        public static IDispatcherEndpointsBuilder AddOrdersRouter(this IDispatcherEndpointsBuilder endpoints)
            => endpoints;
        // .Post<CreateOrder>(
        //     path: "order",
        //     afterDispatch: (command, context) => context.Response.Created($"orders/{command.Id}"))
        // .Get<GetAllOrders, IEnumerable<Order>>(
        //     path: "orders/get");
    }
}