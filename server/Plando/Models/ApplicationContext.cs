using Microsoft.EntityFrameworkCore;
using Plando.Models.Laundries;
using Plando.Models.Orders;
using Plando.Models.Services;
using Plando.Models.Users;

namespace Plando.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Identity> Identities { get; set; }
        public DbSet<Laundry> Laundries { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceAvailability> ServiceAvailabilities { get; set; }
        public DbSet<ServiceAddedEvent> ServiceAddedEvents { get; set; }
        public DbSet<ServiceRemovedEvent> ServiceRemovedEvents { get; set; }
        public DbSet<ServiceCompletedEvent> ServiceCompletedEvents { get; set; }
        public DbSet<OrderCreatedEvent> OrderCreatedEvents { get; set; }
        public DbSet<OrderPassedEvent> OrderPassedEvents { get; set; }
        public DbSet<OrderFinishedEvent> OrderFinishedEvents { get; set; }
    }
}