using System.Threading.Tasks;
using Convey.CQRS.Queries;
using Plando.Common;
using Plando.Models;
using Plando.Models.Laundries;

namespace Plando.Queries.Laundries
{
    public class GetLaundryById : IQuery<Laundry>
    {
        public int Id { get; set; }
    }

    public class GetLaundryByIdHandler : HandlerWithApplicationContext, IQueryHandler<GetLaundryById, Laundry>
    {
        public GetLaundryByIdHandler(ApplicationContext context) : base(context) { }
        public async Task<Laundry> HandleAsync(GetLaundryById query)
        {
            return await _context.Laundries.FindAsync(query.Id);
        }
    }
}