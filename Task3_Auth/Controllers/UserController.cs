using Microsoft.AspNetCore.Mvc;
using Task3_Auth.Data;
using Task3_Auth.Models;

namespace Task3_Auth.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext context;
        public UserController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user) {
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Login(User user) {
            var cheackUser=context.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password);
            if (cheackUser.Any())
            {
                return Content("all of employee");
            }
            ViewBag.Error = "invalid username / password";
            return View(user);
        }
        public IActionResult Index()
        {
            var cheackUser = context.Users.Where(x => x.IsAcrive== false);
            if (cheackUser.Any())
            {
                return View(cheackUser);
            }
          
            return Content("there is an error");
        }
        [HttpPost]
        public IActionResult ChangeStatus(Guid id)
        {
            var finduser = context.Users.Find(id);
            
            finduser.IsAcrive= true;
           context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
