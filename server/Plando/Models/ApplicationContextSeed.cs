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
                var administrator = new User
                {
                    Email = "admin@plando.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                };

                var administratorIdentity = new Identity
                {
                    Email = administrator.Email,
                    Password = "ASDqwe!@#",
                    Role = UserRole.Administrator
                };

                context.Users.Add(administrator);
                context.Identities.Add(administratorIdentity);

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