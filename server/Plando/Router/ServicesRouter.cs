using Convey.WebApi.CQRS;

namespace Plando.Router
{
    public static class ServicesRouter
    {
        internal static IDispatcherEndpointsBuilder AddServicesRouter(this IDispatcherEndpointsBuilder endpoints)
            => endpoints;
    }
}