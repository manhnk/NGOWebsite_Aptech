using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLogicLayer;

namespace NGOWebsite.Areas.Admin.Controllers
{
    public class InformationsController : Controller
    {
        //
        // GET: /Admin/Informations/

        public ActionResult ListInformations()
        {
            List<Informations> ls = InformationsBusiness.GetAllInformations();
            if (ls.Count > 0)
            {
                return View(ls);
            }
            return View();
        }

        //
        // GET: /Admin/Informations/Details/5

        public ActionResult Details(int id)
        {
            List<Informations> ls = InformationsBusiness.GetInformationsById(id);
            if (ls.Count > 0)
            {
                return View(ls[0]);
            }
            return View();
        }

        //
        // GET: /Admin/Informations/Create

        public ActionResult Create()
        {
            List<Menu> lsMenu = MenuBusiness.GetAllMenu();
            ViewData["lsMenu"] = new SelectList(lsMenu, "Id", "Subject"); 
            return View();
        }

        [HttpPost]
        public JsonResult CheckSubjectExisted(string subject, int? id)
        {
             bool check=false;
            List<Models.Informations> ls = InformationsBusiness.CheckInformationExisted(subject, id);
            if (ls.Count > 0)
            {
                check = true;
            }
            return Json(check == false);
        }

        //
        // POST: /Admin/Informations/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateProcess(FormCollection frm)
        {
            int kt = 0;
            try
            {
                int ? parentId = null;
                if (frm["ParentId"] != "" && frm["ParentId"]!=null)
                {
                    parentId = int.Parse(frm["ParentId"]);
                }

                int? postion = null;
                if (frm["Position"] != null && frm["Position"] != "")
                {
                    postion = int.Parse(frm["Position"]);
                }
                // TODO: Add insert logic here
                Models.Informations ad = new Models.Informations()
                {
                    Subject = frm["Subject"],
                    TextTooltip = frm["TextTooltip"],
                    Contents = frm["Contents"],
                    Links = frm["Links"],
                    ParentId = parentId,
                    Position= postion
                };

                kt = InformationsBusiness.AddInformations(ad);
            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("ListInformations", "Informations", new { add = "success" });
            }
            else
            {
                return RedirectToAction("ListInformations", "Informations", new { add = "error" });
            }
        }

        //
        // GET: /Admin/Informations/Edit/5

        public ActionResult Edit(int id)
        {
            List<Menu> lsMenu = MenuBusiness.GetAllMenu();
            ViewData["lsMenu"] = new SelectList(lsMenu, "Id", "Subject");

            List<Informations> ls = InformationsBusiness.GetInformationsById(id);
            return View(ls[0]);
        }

        //
        // POST: /Admin/Informations/Edit/5

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult EditProcess(int id, FormCollection frm)
        {
            int kt = 0;
            try
            {
                int? parentId = null;
                if (frm["ParentId"] != "" && frm["ParentId"] != null)
                {
                    parentId = int.Parse(frm["ParentId"]);
                }

                int? postion = null;
                if (frm["Position"] != null && frm["Position"] != "")
                {
                    postion = int.Parse(frm["Position"]);
                }
                // TODO: Add insert logic here
                Models.Informations ad = new Models.Informations()
                {
                    Id=int.Parse(frm["Id"]),
                    Subject = frm["Subject"],
                    TextTooltip = frm["TextTooltip"],
                    Contents = frm["Contents"],
                    Links = frm["Links"],
                    ParentId = parentId,
                    Position = postion
                };

                kt = InformationsBusiness.EditInformations(ad);
            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("ListInformations", "Informations", new { update = "success" });
            }
            else
            {
                return RedirectToAction("ListInformations", "Informations", new { update = "error" });
            }
        }

        //
        // GET: /Admin/Informations/Delete/5

        public ActionResult Delete(int id)
        {
            int kt = 0;
            try
            {
                kt = InformationsBusiness.DeleteInformations(id);
            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("ListInformations", "Informations", new { delete = "success" });
            }
            else
            {
                return RedirectToAction("ListInformations", "Informations", new { delete = "error" });
            }
        }

    }
}
