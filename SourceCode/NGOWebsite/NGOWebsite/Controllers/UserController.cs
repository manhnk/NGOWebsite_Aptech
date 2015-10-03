using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NGOWebsite.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
             return View();
        }

        [AllowAnonymous]
        public ActionResult Program()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Donation()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Partners()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult Stories()
        {
            return View();
        }

        public ActionResult Member()
        {
            return View();
        }

        public ActionResult Help()
        {
            return View();
        }

        public ActionResult Education()
        {
            return View();
        }

        public ActionResult RecentProgram()
        {
            return View();
        }
    }


}
