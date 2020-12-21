using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using Microsoft.EntityFrameworkCore;
using Plando.Common;
using Plando.Models;
using Plando.Models.Laundries;

namespace Plando.Queries.Laundries
{
    public class GetAllLaundries : PaginatedQuery, IQuery<IEnumerable<Laundry>>
    {
        public int? UserId { get; set; } = null;

    }

    public class GetAllLaundriesHandler : HandlerWithApplicationContext, IQueryHandler<GetAllLaundries, IEnumerable<Laundry>>
    {
        public GetAllLaundriesHandler(ApplicationContext context) : base(context) { }
        public async Task<IEnumerable<Laundry>> HandleAsync(GetAllLaundries query)
        {
            var laundries = await _context.Laundries
                // .Include(x => x.Services)
                .Skip(query.Page * query.PerPage)
                .Take(query.PerPage)
                .ToListAsync();

            return laundries
                .AsEnumerable();
        }


    }
}