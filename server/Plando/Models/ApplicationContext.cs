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
            modelBuilder
                .Entity<LaundryEmployee>()
                .HasKey(x => new { x.LaundryId, x.ManagerId });

            modelBuilder
                .Entity<OrderCreatedEvent>()
                .HasOne<OrderPassedEvent>(x => x.OrderPassedEvent)
                .WithOne(x => x.OrderCreatedEvent)
                .HasForeignKey<OrderPassedEvent>(x => x.OrderId);

            modelBuilder
                .Entity<OrderCreatedEvent>()
                .HasOne<OrderFinishedEvent>(x => x.OrderFinishedEvent)
                .WithOne(x => x.OrderCreatedEvent)
                .HasForeignKey<OrderFinishedEvent>(x => x.OrderId);

            modelBuilder
                .Entity<ServiceAddedEvent>()
                .HasOne<OrderCreatedEvent>(x => x.OrderCreatedEvent)
                .WithMany(x => x.ServiceAddedEvents)
                .HasForeignKey(x => x.OrderId);

            modelBuilder
                .Entity<ServiceRemovedEvent>()
                .HasOne<OrderCreatedEvent>(x => x.OrderCreatedEvent)
                .WithMany(x => x.ServiceRemovedEvents)
                .HasForeignKey(x => x.OrderId);

            modelBuilder
                .Entity<ServiceCompletedEvent>()
                .HasOne<OrderCreatedEvent>(x => x.OrderCreatedEvent)
                .WithMany(x => x.ServiceCompletedEvents)
                .HasForeignKey(x => x.OrderId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Identity> Identities { get; set; }
        public DbSet<Laundry> Laundries { get; set; }
        public DbSet<LaundryEmployee> LaundryEmployees { get; set; }
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