using Entities;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MvcKurumsalSite.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            User user = new User()
            { 
                Email = "admin@siteadi.com",
                Name = "Admin",
                Password = "123456",
                IsActive = true,
                UserName = "admin"
            };
            if (context.Users.Any())
            {
                context.Users.AddOrUpdate(user);
                context.SaveChanges();
            }
            base.Seed(context);
        }
    }
}
