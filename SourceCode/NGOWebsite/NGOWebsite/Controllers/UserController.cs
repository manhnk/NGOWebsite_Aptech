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
        public ActionResult Login()
        {
            if (Session["user_login"] != null)
            {
                return RedirectToAction("Home", "User");
            }
            else return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult LoginProcess(FormCollection frm)
        {
            int check = 0;
            string user = frm["UserName"];
            string pass = frm["Password"];

            List<Models.Member> ls = MemberBusiness.CheckLogin(user, pass);

            if (ls.Count > 0)
            {
                Session["user_login"] = ls[0];

                HttpCookie c = new HttpCookie("user_ck");
                c.Values["user"] = user;
                c.Values["pass"] = pass;

                if (frm["cbRemember"].ToString().Contains("rmb"))
                {
                    c.Expires = DateTime.Now.AddDays(10);
                }
                else
                {
                    c.Expires = DateTime.Now.AddDays(-1);
                }
                Response.Cookies.Add(c);
                check = 1;

            }

            if (check == 1) return RedirectToAction("Home", "User");
            else
            {
                Models.Member mb = new Models.Member() { UserName = user, Password = pass };
                Session["draftUserAcc"] = mb;
                return RedirectToAction("Login", "User", new { error = "-1" });
            }


        }

        
        [AllowAnonymous]
        public ActionResult Programs()
        {
            return View();
        }


        public ActionResult Gallery()
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
