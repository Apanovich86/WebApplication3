using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class UsersController : Controller
    {
        public ApplicationDbContext context = new ApplicationDbContext();
        // GET: Users
        public ActionResult Get()
        {
            var users = context.Users.ToList();
            return View("Get", users);
        }
        public ActionResult ListUsers()
        {
            return View(context.Users.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ApplicationUser prof)
        {
            if (prof != null)
            {
                context.Users.Add(prof);
                context.SaveChanges();
            }
            return RedirectToAction("Get");
        }

        public ActionResult Edit(string id)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(ApplicationUser appUser)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == appUser.Id);
            if (user != null)
            {
                user.Email = appUser.Email;
                user.Age = appUser.Age;
                user.BirthDate = appUser.BirthDate;
                user.ImagePath = appUser.ImagePath;
                context.SaveChanges();
            }
            return RedirectToAction("Get");
        }
        public async Task<ActionResult> Delete(string id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
            return RedirectToAction("Get");
        }

    }
}
      

