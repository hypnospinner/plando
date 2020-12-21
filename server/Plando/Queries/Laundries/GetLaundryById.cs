using System.Threading.Tasks;
using System.Linq;
using Convey.CQRS.Queries;
using Plando.Common;
using Plando.Models;
using Plando.Models.Orders;
using Plando.Models.Laundries;
using Microsoft.EntityFrameworkCore;
using Plando.Models.Users;
using Plando.Models.Services;

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
            if (query.UserId is null)
            {
                var _laundry = await _context.Laundries
                        .FirstOrDefaultAsync(x => x.Id == query.Id);

                _laundry.Services = await _context.LaundryServices
                    .Where(x => x.LaundryId == _laundry.Id)
                    .Select(x => new LaundryService()
                    {
                        LaundryId = x.LaundryId,
                        Service = x.Service
                    })
                    .ToListAsync();

                return _laundry;
            }

            var user = await _context.Users
                .Include(x => x.Identity)
                .Include(x => x.Laundry)
                .SingleOrDefaultAsync(x => x.Id == query.UserId);

            switch (user.Identity.Role)
            {
                case UserRole.Client:
                    var laundry1 = await _context.Laundries
                        .FirstOrDefaultAsync(x => x.Id == query.Id);

                    laundry1.Services = await _context.LaundryServices
                        .Where(x => x.LaundryId == laundry1.Id)
                        .Select(x => new LaundryService()
                        {
                            LaundryId = x.LaundryId,
                            Service = x.Service
                        })
                        .ToListAsync();

                    return laundry1;

                case UserRole.Manager:
                    if (user.Laundry is not null && user.LaundryId == query.Id)
                    {
                        var laundry2 = await _context.Laundries
                            .Include(x => x.Orders)
                            .FirstOrDefaultAsync(x => x.Id == query.Id);

                        laundry2.Services = await _context.LaundryServices
                            .Where(x => x.LaundryId == laundry2.Id)
                            .Select(x => new LaundryService()
                            {
                                LaundryId = x.LaundryId,
                                Service = x.Service
                            })
                            .ToListAsync();

                        return laundry2;
                    }
                    else
                    {
                        return await _context.Laundries
                            .FirstOrDefaultAsync(x => x.Id == query.Id);
                    }
                case UserRole.Administrator:
                    var laundry = await _context.Laundries
                            .Include(x => x.Orders)
                            .FirstOrDefaultAsync(x => x.Id == query.Id);

                    laundry.Services = await _context.LaundryServices
                        .Where(x => x.LaundryId == laundry.Id)
                        .Select(x => new LaundryService()
                        {
                            LaundryId = x.LaundryId,
                            Service = x.Service
                        })
                        .ToListAsync();

                    return laundry;
            }

            return null;
        }
    }
}