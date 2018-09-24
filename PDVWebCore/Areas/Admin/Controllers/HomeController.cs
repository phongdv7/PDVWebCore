using PDVWebCore.Areas.Admin.Models.Customers;
using PDVWebCore.Areas.Admin.Models.Home;
using PDVWebCore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PDVWebCore.Commons;

namespace PDVWebCore.Areas.Admin.Controllers
{ 
    public class HomeController : Controller
    {
        private PDVWebCoreContext db = new PDVWebCoreContext();
        // GET: Admin/Home
        [AuthorizeUser(Role = "ADMINISTRATORS")]
        public ActionResult Index()
        {
            return View();
        }

        // Get: Login
        public ActionResult Login()
        {
            return View();
        }
        // Post: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Username, Password, RememberMe")] LoginModel customer)
        {
            //Customer user = new Customer();
            Customer user = db.Customers
            .Include(i => i.CustomerRoles)
            .Where(c => c.Username == customer.Username && c.Password == customer.Password)
            .SingleOrDefault();

            if (user != null)
            {
                Session["UserLoggedIn"] = user.Username;
                Session["UserRoles"] = user.CustomerRoles;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu");
                return View(customer);
            }
        }
    }
}