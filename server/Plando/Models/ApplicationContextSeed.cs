using System.Linq;
using Plando.Models.Users;

namespace Plando.Models
{
    public static class ApplicationContextSeed
    {
        public static void Initialize(ApplicationContext context)
        {
            context.Database.EnsureCreated();
            context
                .SeedAdministrators()
                .SeedLaundries();
        }

        private static ApplicationContext SeedAdministrators(this ApplicationContext context)
        {
            if (!context.Users.Any())
            {
                var identity = new Identity
                {
                    UserId = 1,
                    Email = "admin@plando.com",
                    Password = "ASDqwe!@#",
                    Role = UserRole.Administrator,
                };

                var user = new User
                {
                    Id = 1,
                    Email = "admin@plando.com",
                    FirstName = "Admin",
                    LastName = "Admin"
                };

                context.Identities.Add(identity);
                context.Users.Add(user);

                context.SaveChanges();
            }

            return context;
        }

        private static ApplicationContext SeedLaundries(this ApplicationContext context)
        {
            // TODO: implement laundry and managers auto-population
            return context;
        }
    }
}