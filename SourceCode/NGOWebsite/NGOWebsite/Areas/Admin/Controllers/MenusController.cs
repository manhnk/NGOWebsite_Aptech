using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLogicLayer;

namespace NGOWebsite.Areas.Admin.Controllers
{
    public class MenusController : Controller
    {
        //
        // GET: /Admin/Menu/

        public ActionResult ListMenu()
        {
            if (Session["mvc_user"] != null)
            {
                Models.Admin ad = Session["mvc_user"] as Models.Admin;
                if (!ad.IsSuperAdmin)
                {
                    return RedirectToAction("Index", "HomeAdmin");
                }
            }

            List<Menu> ls = MenuBusiness.GetAllMenu();

            return View(ls);
        }

        //
        // GET: /Admin/Menu/Details/5

        public ActionResult Details(int id)
        {
            if (Session["mvc_user"] != null)
            {
                Models.Admin ad = Session["mvc_user"] as Models.Admin;
                if (!ad.IsSuperAdmin)
                {
                    return RedirectToAction("Index", "HomeAdmin");
                }
            }

            List<Menu> ls = MenuBusiness.GetMenuById(id);

            return View(ls[0]);
        }

        //
        // GET: /Admin/Menu/Create

        public ActionResult Create()
        {
            if (Session["mvc_user"] != null)
            {
                Models.Admin ad = Session["mvc_user"] as Models.Admin;
                if (!ad.IsSuperAdmin)
                {
                    return RedirectToAction("Index", "HomeAdmin");
                }
            }
            return View();
        }


        [HttpPost]
        public JsonResult CheckSubjectExisted(string subject, int? id)
        {
            bool check = false;
            List<Models.Menu> ls = MenuBusiness.CheckMenuExisted(subject, id);
            if (ls.Count > 0)
            {
                check = true;
            }
            return Json(check == false);
        }
        //
        // POST: /Admin/Menu/Create

        [HttpPost]
        public ActionResult CreateProcess(FormCollection frm)
        {
            int kt = 0;
            try
            {

                int? postion = null;
                if (frm["Position"] != null && frm["Position"] != "")
                {
                    postion = int.Parse(frm["Position"]);
                }
                // TODO: Add insert logic here
                Models.Menu ad = new Models.Menu()
                {
                    Subject = frm["Subject"],
                    TextTooltip = frm["TextTooltip"],
                    Links = frm["Links"],
                    Position = postion
                };

                kt = MenuBusiness.AddMenu(ad);
            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("ListMenu", "Menus", new { add = "success" });
            }
            else
            {
                return RedirectToAction("ListMenu", "Menus", new { add = "error" });
            }
        }

        //
        // GET: /Admin/Menu/Edit/5

        public ActionResult Edit(int id)
        {
            if (Session["mvc_user"] != null)
            {
                Models.Admin ad = Session["mvc_user"] as Models.Admin;
                if (!ad.IsSuperAdmin)
                {
                    return RedirectToAction("Index", "HomeAdmin");
                }
            }

            List<Menu> ls = MenuBusiness.GetMenuById(id);

            return View(ls[0]);
        }

        //
        // POST: /Admin/Menu/Edit/5

        [HttpPost]
        public ActionResult EditProcess(FormCollection frm)
        {
            int kt = 0;
            try
            {

                int? postion = null;
                if (frm["Position"] != null && frm["Position"] != "")
                {
                    postion = int.Parse(frm["Position"]);
                }
                // TODO: Add insert logic here
                Models.Menu ad = new Models.Menu()
                {
                    Id = int.Parse(frm["Id"]),
                    Subject = frm["Subject"],
                    TextTooltip = frm["TextTooltip"],
                    Links = frm["Links"],
                    Position = postion
                };

                kt = MenuBusiness.EditMenu(ad);
            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("ListMenu", "Menus", new { update = "success" });
            }
            else
            {
                return RedirectToAction("ListMenu", "Menus", new { update = "error" });
            }
        }

        //
        // GET: /Admin/Menu/Delete/5

        public ActionResult Delete(int id)
        {
            if (Session["mvc_user"] != null)
            {
                Models.Admin ad = Session["mvc_user"] as Models.Admin;
                if (!ad.IsSuperAdmin)
                {
                    return RedirectToAction("Index", "HomeAdmin");
                }
            }

            int kt = 0;
            try
            {
                kt = MenuBusiness.DeleteMenu(id);
            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("ListMenu", "Menus", new { delete = "success" });
            }
            else
            {
                return RedirectToAction("ListMenu", "Menus", new { delete = "error" });
            }

        }


    }
}
