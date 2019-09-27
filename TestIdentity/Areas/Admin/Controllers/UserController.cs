using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestIdentity.Identity;

namespace TestIdentity.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            ApplicationDBContext db = new ApplicationDBContext();
            List<ApplicationUser> user = db.Users.ToList();
            return View(user);
        }
    }
}