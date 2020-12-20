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
        public int? UserId { get; set; } = null;
    }

    public class GetLaundryByIdHandler : HandlerWithApplicationContext, IQueryHandler<GetLaundryById, Laundry>
    {
        public GetLaundryByIdHandler(ApplicationContext context) : base(context) { }
        public async Task<Laundry> HandleAsync(GetLaundryById query)
        {
            // TODO: give information about available services for any user
            // TODO: if user is manager or admin that also send info about opened orders 
            return await _context.Laundries.FindAsync(query.Id);
        }
    }
}