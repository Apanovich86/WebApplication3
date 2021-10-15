using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.Models.Entities;

namespace homework1.Controllers
{
    public class PlansController : Controller
    {
        public ApplicationDbContext context = new ApplicationDbContext();
        public ActionResult Get()
        {
            var user = context.Users.FirstOrDefault(x =>x.UserName == User.Identity.Name);
            var result = context.Plans.Where(x => x.UserId == user.Id);
            if (result != null)
            {
                return View("Get", result);
            }
            return View("Get", new List<Plan>());
        }
        public ActionResult Index()
        {
            var plans = context.Plans;
            return View(plans);
        }
        public async Task<ActionResult> Delete(int id)
        {
            var plan = await context.Plans.FirstOrDefaultAsync(x => x.Id == id);
            if (plan != null)
            {
                context.Plans.Remove(plan);
                await context.SaveChangesAsync();
            }
            return RedirectToAction("Get");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Plan plan)
        {
            if (plan != null)
            {
                var user = context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
                plan.UserId = user.Id;
                context.Plans.Add(plan);
                await context.SaveChangesAsync();
            }
            return RedirectToAction("Get");
        }
        public ActionResult Edit(int id)
        {
            var plan = context.Plans.FirstOrDefault(x => x.Id == id);
            return View(plan);
        }
        [HttpPost]
        public ActionResult Edit(Plan plan)
        {
            var plan_ = context.Plans.FirstOrDefault(x => x.Id == plan.Id);
            if (plan_ != null)
            {
                plan_.Image = plan.Image;
                plan_.Title = plan.Title;
                plan_.Deadline = plan.Deadline;
                plan_.Description = plan.Description;
                context.SaveChanges();
            }
            return RedirectToAction("Get");
        }
        [HttpPost]
        public ActionResult Search(string searchString)
        {
            var result = context.Plans.Where(x => x.Title.Contains(searchString) || x.Description.Contains(searchString));
            return View("Get", result);
        }
        public ActionResult Sort()
        {
            var plans = from p in context.Plans
                        orderby p.Title ascending
                        select p;
            return View("Get", plans);
        }
    }
}