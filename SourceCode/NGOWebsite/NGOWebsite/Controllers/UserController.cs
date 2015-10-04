using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using Models;

namespace NGOWebsite.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Home()
        {
             return View();
        }

        [AllowAnonymous]
        public ActionResult Programs()
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
        

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Stories()
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
