﻿using System;
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

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Home", "User");

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



        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterProcess(FormCollection frm)
        {

            int kt = 0;
            try
            {
                int i = 0;
                if (frm["cbIsMOT"].ToString().Contains("rmb"))
                {
                    i = 1;
                }
                // TODO: Add insert logic here
                Models.Member ad = new Models.Member()
                {
                    UserName = frm["UserName"],
                    Password = frm["Password"],
                    FullName = frm["FullName"],
                    Gender = frm["Gender"],
                    Phone = frm["Phone"],
                    Address = frm["Address"],
                    Email = frm["Email"],
                    IsMemberOfTeam = i,
                    IsDeleted = 0,
                    Image = ""
                };
                // In error, need to be fixed!
                kt = MemberBusiness.AddMember(ad);

            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("Register", "User", new { add = "success" });
            }
            else
            {
                return RedirectToAction("Register", "User", new { add = "error" });
            }

        }



        public ActionResult Profile()
        {
            Models.Member ad = new Models.Member();
            ad = (Member)Session["user_login"];
            if (Session["user_login"] != null)
            {
                List<Models.Member> ls = MemberBusiness.GetMemberById(ad.Id);
                if (ls.Count > 0)
                {
                    return View(ls[0]);
                }
                else return null;
            }
            else return null;

        }

        //
        // POST: /Admin/Admin/Edit/5

        [HttpPost]
        public ActionResult EditProcess(FormCollection frm)
        {
            int kt = 0;
            try
            {
                bool actived = false;
                if (frm["cbIsActived"].ToString().Contains("rmb"))
                {
                    actived = true;
                }
                // TODO: Add insert logic here
                Models.Admin ad = new Models.Admin()
                {
                    Id = int.Parse(frm["Id"]),
                    UserName = frm["UserName"],
                    FullName = frm["FullName"],
                    Gender = frm["Gender"],
                    Phone = frm["Phone"],
                    Address = frm["Address"],
                    Email = frm["Email"],
                    IsActived = actived,
                };

                kt = AdminBusiness.EditAdmin(ad);

            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("ListAdmin", "Admin", new { update = "success" });
            }
            else
            {
                return RedirectToAction("ListAdmin", "Admin", new { update = "error" });
            }
        }
    }


}
