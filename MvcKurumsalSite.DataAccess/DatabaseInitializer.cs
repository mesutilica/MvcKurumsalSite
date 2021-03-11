using System.Linq;
using System.Data.Entity;
using Entities;
using System.Data.Entity.Migrations;

namespace MvcKurumsalSite.DataAccess
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            User user = new User()
            {
                Email = "admin@siteadi.com",
                Name = "Admin",
                Password = "123456",
                IsActive = true,
                UserName = "admin"
            };
            
            if (context.Users.FirstOrDefault() == null)
            {
                context.Users.AddOrUpdate(user);
                context.SaveChanges();
            }
            base.Seed(context);
        }
    }
}
