using System.Linq;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext context;
        public ProfileController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Profile
        public ActionResult Index()
        {
            var user = context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            var profile = new ProfileViewModel()
            {
                Id = user.Id,
                Age = user.Age,
                Email = user.Email,
                BirthDate = user.BirthDate,
                ImagePath = user.ImagePath
            };
            return View(profile);
        }
    }
}