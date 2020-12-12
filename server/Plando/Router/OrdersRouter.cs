using Convey.WebApi.CQRS;

namespace Plando.Router
{
    internal static class OrdersRouter
    {
        public static IDispatcherEndpointsBuilder AddOrdersRouter(this IDispatcherEndpointsBuilder endpoints)
            => endpoints;
    }
}