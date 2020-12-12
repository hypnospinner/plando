using Convey.WebApi;
using Convey.WebApi.CQRS;
using Plando.Commands.Laundries;

namespace Plando.Router
{
    public static class LaundriesRouter
    {
        public static IDispatcherEndpointsBuilder AddLaundriesRouter(this IDispatcherEndpointsBuilder endpoints)
            => endpoints
            // add new laundry
            .Post<CreateLaundry>(
                path: "laundries",
                afterDispatch: async (command, context) =>
                {
                    await context.Response.Created($"laundries/{command.Id}");

                })
            .Delete<DeleteLaundry>(
                path: "laundries/{Id}",
                afterDispatch: async (command, context) =>
                {
                    context.Response.StatusCode = 204;
                    await context.Response.WriteJsonAsync(new
                    {
                        id = command.Id
                    });
                });
    }
}