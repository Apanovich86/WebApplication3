using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models.Entities;

namespace WebApplication3.Models.Initializer
{
    public class DataBaseInitializer
    {
        public static void Seed()
        {
            using (var context = new ApplicationDbContext())
            {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем две роли
            var adminRole = new IdentityRole { Name = "Admin" };
            var userRole = new IdentityRole { Name = "User" };

            // добавляем роли в бд
            roleManager.Create(adminRole);
            roleManager.Create(userRole);

            // создаем пользователей
            var admin = new ApplicationUser { Email = "anna@gmail.com", UserName = "anna@gmail.com" };
            string password = "Qwerty1-";
            var result = userManager.Create(admin, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, adminRole.Name);
                userManager.AddToRole(admin.Id, userRole.Name);
            }
                context.Plans.Add(new Plan()
                {
                    Description = "sdffghgjh",
                    Image = "dsfghjk",
                    Title = "sdgfhjkl"
                });
                context.SaveChanges();
        }
        }
    }
}