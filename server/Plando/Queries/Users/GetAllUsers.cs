using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using Microsoft.EntityFrameworkCore;
using Plando.DTOs;
using Plando.Models;

namespace Plando.Queries.Users
{
    public class GetAllUsers : IQuery<IEnumerable<UserDTO>>
    {
        public int Page { get; set; } = 0;
        public int PerPage { get; set; } = 20;
    }

    public class GetAllUsersHandler : IQueryHandler<GetAllUsers, IEnumerable<UserDTO>>
    {
        private readonly ApplicationContext _context;

        public GetAllUsersHandler(ApplicationContext context)
        {
            _context = context;
        }

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