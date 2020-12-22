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
    public class GetBusyManagers : PaginatedQuery, IQuery<IEnumerable<UserDTO>> { }

    public class GetBusyManagersHandler : HandlerWithApplicationContext, IQueryHandler<GetBusyManagers, IEnumerable<UserDTO>>
    {
        public GetBusyManagersHandler(ApplicationContext context) : base(context) { }
        public async Task<IEnumerable<UserDTO>> HandleAsync(GetBusyManagers query)
        {
            var busyManagers = await _context.Users
                            .Include(x => x.Identity)
                            .Where(x => (x.Identity.Role == UserRole.Manager) && (x.LaundryId != null))
                            .Skip(query.Page * query.PerPage)
                            .Take(query.PerPage)
                            .ToListAsync();

            return busyManagers
                    .Select(x => new UserDTO(x))
                    .AsEnumerable();

        }
    }
}