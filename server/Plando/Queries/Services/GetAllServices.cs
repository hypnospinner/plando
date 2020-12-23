using System.Collections.Generic;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using Plando.Common;
using System.Linq;
using Plando.Models.Services;
using Plando.Models.Orders;
using Microsoft.EntityFrameworkCore;
using static Plando.Common.TypedException;
using Plando.Models;

namespace Plando.Queries.Services
{
    public class GetAllServices : PaginatedQuery, IQuery<IEnumerable<Service>> { }

    public class GetAllServicesHandler : HandlerWithApplicationContext, IQueryHandler<GetAllServices, IEnumerable<Service>>
    {
        public GetAllServicesHandler(ApplicationContext context) : base(context) { }

        public async Task<IEnumerable<Service>> HandleAsync(GetAllServices query)
        {
            var services = await _context.Services
                                .Skip(query.Page * query.PerPage)
                                .Take(query.PerPage)
                                .ToArrayAsync();
            return services;
        }
    }
}