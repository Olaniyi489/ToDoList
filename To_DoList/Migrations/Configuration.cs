namespace To_DoList.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using To_DoList.Models;
    


    internal sealed class Configuration : DbMigrationsConfiguration<To_DoList.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(To_DoList.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // context.People.AddOrUpdate(
            // p => p.Fullname,
            // new Person { FullName = "Salami Waris" };
            // new Person { FullName = "Benjamin John" };
            // new Person { FullName = "Obanwo Oluwatom" };
            // );
            AddUsers(context);
        }

        void AddUsers(To_DoList.Models.ApplicationDbContext context)
        {
            var user = new ApplicationUser { UserName = "user1@gmail.com" };
            var un = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            un.Create(user, "password");

            //var user1 = new ApplicationUser { UserName = "olawareez96@gmail.com" };
            //var un1 = new UserManager<ApplicationUser>(
            //    new UserStore<ApplicationUser>(context));
            //un.Create(user, "Maths2002*");
        }
    }
}
