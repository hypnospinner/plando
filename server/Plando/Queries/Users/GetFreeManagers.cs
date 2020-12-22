using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using Microsoft.EntityFrameworkCore;
using Plando.Common;
using Plando.DTOs;
using Plando.Models;
using Plando.Models.Users;

namespace Plando.Queries.Users
{
    public class GetFreeManagers : PaginatedQuery, IQuery<IEnumerable<UserDTO>> { }

    public class GetFreeManagersHandler : HandlerWithApplicationContext, IQueryHandler<GetFreeManagers, IEnumerable<UserDTO>>
    {
        public GetFreeManagersHandler(ApplicationContext context) : base(context) { }
        public async Task<IEnumerable<UserDTO>> HandleAsync(GetFreeManagers query)
        {
            var freeManagers = await _context.Users
                            .Include(x => x.Identity)
                            .Where(x => (x.Identity.Role == UserRole.Manager) && (x.LaundryId == null))
                            .Skip(query.Page * query.PerPage)
                            .Take(query.PerPage)
                            .ToListAsync();

            return freeManagers
                    .Select(x => new UserDTO(x))
                    .AsEnumerable();

        }
    }
}