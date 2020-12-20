using System.Threading.Tasks;
using System.Linq;
using Convey.CQRS.Queries;
using Plando.Common;
using Plando.Models;
using Plando.Models.Orders;
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
            var laundry = await _context.Laundries.FindAsync(query.Id);
            if (laundry.Managers.Any(x => x.Id == query.Id))
            {
                var orders = _context.OrderCreatedEvents
                                        .Where(x => x.LaundryId == query.Id).ToList();

                laundry.Orders = orders;
            }
            var services = _context.LaundryServices
                                        .Where(x => x.LaundryId == query.Id).ToList();

            laundry.Services = services;

            return laundry;

        }
    }
}