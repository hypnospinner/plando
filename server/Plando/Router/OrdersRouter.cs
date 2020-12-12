using System.Collections.Generic;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using Plando.Commands.Order;
using Plando.DTOs;
using Plando.Queries.Order;

namespace Plando.Router
{
    public static class OrdersRouter
    {
        public static IDispatcherEndpointsBuilder AddOrdersRouter(this IDispatcherEndpointsBuilder endpoints)
            => endpoints
            .Post<CreateOrder>(
                path: "orders",
                afterDispatch: async (command, context) =>
                {
                    await context.Response.Created($"orders/{command.Id}");
                }
            );

    }
}