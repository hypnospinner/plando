using System.Collections.Generic;
using System.Threading.Tasks;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using Plando.Commands.Laundries;
using Plando.DTOs;
using Plando.Models.Laundries;
using Plando.Models.Users;
using Plando.Queries.Laundries;
using Plando.Utils;

namespace Plando.Router
{
    internal static class LaundriesRouter
    {
        public static IDispatcherEndpointsBuilder AddLaundriesRouter(this IDispatcherEndpointsBuilder endpoints)
            => endpoints
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
                })
            .Post<DismissManager>(
                path: "laundry/dismiss",
                auth: true,
                roles: UserRole.Administrator.ToString())
            .Post<EmployManager>(
                path: "laundry/employ",
                auth: true,
                roles: UserRole.Administrator.ToString()
            )
            .Get<GetLaundryById, Laundry>(
                path: "laundries/{id}")
            .Get<GetAllLaundries, IEnumerable<Laundry>>(
                path: "laundries");

    }
}