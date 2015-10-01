using System;
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


        public ActionResult ListAdmin()
        {
            List<Models.Admin> ls= AdminBusiness.GetAllAdmin();
            return View(ls);
        }

        public ActionResult ChangeStatus(int id)
        {
            List<Models.Admin> ls=AdminBusiness.GetAdminById(id);
            int check = 0;
            if (ls.Count > 0)
            {
                if (ls[0].IsActived) {
                    ls[0].IsActived = false;
                }
                else {
                    ls[0].IsActived = true;                    
                }

                check = AdminBusiness.EditAdmin(ls[0]);
                if (check > 0)
                {
                    return RedirectToAction("ListAdmin","Admin");
                }
                else
                {
                    return RedirectToAction("ListAdmin", "Admin", new {@error=-1});
                }
            }
            return null;
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

        //
        // GET: /Admin/Admin/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Admin/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Admin/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
