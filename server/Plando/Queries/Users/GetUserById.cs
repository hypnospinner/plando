using System.Threading.Tasks;
using Convey.CQRS.Queries;
using Plando.Common;
using Plando.DTOs;
using Plando.Models;

namespace Plando.Queries.Users
{
    public class GetUserById : IQuery<UserDTO>
    {
        public int Id { get; set; }
    }

    public class GetUserByIdHandler : HandlerWithApplicationContext, IQueryHandler<GetUserById, UserDTO>
    {
        public GetUserByIdHandler(ApplicationContext context) : base(context) { }

        public async Task<UserDTO> HandleAsync(GetUserById query)
        {
            var user = await _context.Users.FindAsync(query.Id);

            return new UserDTO(user);
        }
    }
}