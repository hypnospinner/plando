using Convey.WebApi.CQRS;
using Plando.Commands.Services;
using Plando.Models.Users;
using Plando.Models.Services;
using System.Collections.Generic;
using Plando.Queries.Services;

namespace Plando.Router
{
    public static class ServicesRouter
    {
        internal static IDispatcherEndpointsBuilder AddServicesRouter(this IDispatcherEndpointsBuilder endpoints)
            => endpoints
                .Post<AddService>(
                    path: "service/add",
                    auth: true,
                    roles: UserRole.Administrator.ToString())
                .Post<MakeServiceAvailableInLaundry>(
                    path: "service/enable",
                    auth: true,
                    roles: $"{UserRole.Administrator},{UserRole.Manager}"
                )
                .Get<GetAllServices, IEnumerable<Service>>(
                    path: "services",
                    auth: true,
                    roles: $"{UserRole.Administrator},{UserRole.Manager}"
                );
    }
}