using System.Linq;

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
                    Password = "ASDqwe!@#",
                    FirstName = "Admin",
                    LastName = "Admin",
                    Role = UserRole.Administrator
                };

                context.Users.Add(administrator);
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