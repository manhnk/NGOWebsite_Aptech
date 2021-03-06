﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using Models;
using System.Web.UI.WebControls;

namespace NGOWebsite.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Session["mvc_user"] != null)
            {
                return RedirectToAction("Index", "HomeAdmin");
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

            List<Models.Admin> ls = AdminBusiness.CheckLogin(user, pass);

            if (ls.Count > 0)
            {
                Session["mvc_user"] = ls[0];

                HttpCookie c = new HttpCookie("mvc_login");
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

            if (check == 1) return RedirectToAction("Index", "HomeAdmin");
            else
            {
                Models.Admin ad = new Models.Admin() { UserName=user,Password=pass};
                Session["draftAcc"] = ad;
                return RedirectToAction("Login", "Admin", new { error = "-1" });
            }


        }


        //
        // GET: /Admin/Admin/Details/5

        public ActionResult Details(int id)
        {
            List<Models.Admin> ls = AdminBusiness.GetAdminById(id);
            if (ls.Count > 0)
            {
                return View(ls[0]);
            }
            else return null;
        }

        //
        // GET: /Admin/Admin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Admin/Create

        [HttpPost]
        public ActionResult CreateProcess(FormCollection frm)
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
                    UserName=frm["UserName"],
                    Password = "1234567",
                    FullName = frm["FullName"],
                    Gender = frm["Gender"],
                    Phone = frm["Phone"],
                    Address = frm["Address"],
                    Email = frm["Email"],
                    IsActived = actived,
                    IsSuperAdmin=false
                };

                kt=AdminBusiness.AddAdmin(ad);

            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("ListAdmin", "Admin", new {add="success"});
            }
            else
            {
                return RedirectToAction("ListAdmin", "Admin", new { add = "error" });
            }

        }

        //
        // GET: /Admin/Admin/Edit/5

        public ActionResult Edit(int id)
        {
            List<Models.Admin> ls = AdminBusiness.GetAdminById(id);
            if (ls.Count > 0)
            {
                return View(ls[0]);
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

        //
        // POST: /Admin/Admin/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                int kt=AdminBusiness.DeleteAdmin(id);
                if (kt > 0)
                {
                    return RedirectToAction("ListAdmin", "Admin", new { delete = "success" });
                }
                else
                {
                    return RedirectToAction("ListAdmin", "Admin", new { delete = "error" });
                }
            }
            catch
            {
                return RedirectToAction("ListAdmin", "Admin", new { delete = "error" });
            }
        }

        public ActionResult ListAdmin()
        {
            List<Models.Admin> ls = AdminBusiness.GetAllAdmin();
            return View(ls);
        }

        public ActionResult ChangeStatus(int id)
        {
            List<Models.Admin> ls = AdminBusiness.GetAdminById(id);
            int check = 0;
            if (ls.Count > 0)
            {
                if (ls[0].IsActived)
                {
                    ls[0].IsActived = false;
                }
                else
                {
                    ls[0].IsActived = true;
                }

                check = AdminBusiness.EditAdmin(ls[0]);
                if (check > 0)
                {
                    return RedirectToAction("ListAdmin", "Admin");
                }
                else
                {
                    return RedirectToAction("ListAdmin", "Admin", new { @error = -1 });
                }
            }
            return null;
        }


        [HttpPost]   
        public JsonResult CheckAccExisted(string username,int ? id) {
                    bool check = false;

            List<Models.Admin> ls=AdminBusiness.CheckUserExisted(username,id);
            if (ls.Count > 0)
            {
                check = true;
            }
            return Json(check == false);
        }

        [HttpPost]
        public JsonResult CheckPassword(string password)// name of paramter must be same with name of control 
        {
            bool check = false;
            int id = 0;
           if (Session["mvc_user"] != null)
            {
                Models.Admin ad = Session["mvc_user"] as Models.Admin;
                id = ad.Id;
            }
            

            List<Models.Admin> ls = AdminBusiness.GetAdminById(id);
            if (ls.Count > 0)
            {
                if (ls[0].Password != DataAccessLayer.DataConnect.GetMd5Hash(password))
                {
                    check = true;
                }
            }
            return Json(check == false);
        }



        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePasswordProcess(FormCollection frm)
        {
            int id = 0;
            if (Session["mvc_user"] != null)
            {
                Models.Admin ad = Session["mvc_user"] as Models.Admin;
                id = ad.Id;
            }
            int kt = 0;
            try
            {
                string pass = frm["NewPassword"];

                kt = AdminBusiness.ChangePassword(id, pass);

            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("ListAdmin", "Admin", new { change = "success" });
            }
            else
            {
                return RedirectToAction("ListAdmin", "Admin", new { change = "error" });
            }
        }

       
    }
}
