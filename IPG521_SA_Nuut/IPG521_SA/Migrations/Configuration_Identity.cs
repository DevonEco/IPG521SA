namespace IPG521_SA.Migrations
{
    using IPG521_SA.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration_Identity : DbMigrationsConfiguration<IPG521_SA.Models.ApplicationDbContext>
    {
        public Configuration_Identity()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(IPG521_SA.Models.ApplicationDbContext context)
        {
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);

            var roleAdmin = new IdentityRole { Name = "Admin" };
            var roleUser = new IdentityRole { Name = "Client" };

            if (!manager.RoleExists(roleAdmin.Name))
                manager.Create(roleAdmin);

            if (!manager.RoleExists(roleUser.Name))
                manager.Create(roleUser);

            // Default user 
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            ApplicationUser adminUser = new ApplicationUser
            {
                Email = "admin@ctu.co.za",
                UserName = "admin@ctu.co.za"
            };
            //Admin user password
            var results = userManager.Create(adminUser, "Secret123$");

            if (results.Succeeded)
                userManager.AddToRoles(adminUser.Id, roleAdmin.Name);

            base.Seed(context);

        }
    }
}
