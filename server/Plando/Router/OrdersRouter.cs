using System.Collections.Generic;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using Plando.Commands.Order;
using Plando.DTOs;

namespace Plando.Router
{
    internal static class OrdersRouter
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