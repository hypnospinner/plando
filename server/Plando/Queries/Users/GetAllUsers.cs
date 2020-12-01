using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using Microsoft.EntityFrameworkCore;
using Plando.Common;
using Plando.DTOs;
using Plando.Models;

namespace Plando.Queries.Users
{
    public class GetAllUsers : IQuery<IEnumerable<UserDTO>>
    {
        public int Page { get; set; } = 0;
        public int PerPage { get; set; } = 20;
    }

    public class GetAllUsersHandler : HandlerWithApplicationContext, IQueryHandler<GetAllUsers, IEnumerable<UserDTO>>
    {
        public GetAllUsersHandler(ApplicationContext context) : base(context) { }

        public async Task<IEnumerable<UserDTO>> HandleAsync(GetAllUsers query)
        {
            var users = await _context.Users
                .Skip(query.Page * query.PerPage)
                .Take(query.PerPage)
                .ToListAsync();

            return users
                .Select(x => new UserDTO(x))
                .AsEnumerable();
        }
    }
}