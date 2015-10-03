using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using Models;

namespace NGOWebsite.Areas.Admin.Controllers
{
    public class CauseOfDonationController : Controller
    {
        //
        // GET: /Admin/CauseOfDonation/

        public ActionResult ListCause()
        {
            List<CauseOfDonation> ls = CauseOfDonationBusiness.GetAllCauseOfDonation();
            return View(ls);
        }

        //
        // GET: /Admin/CauseOfDonation/Details/5

        public ActionResult Details(int id)
        {
            List<CauseOfDonation> ls = CauseOfDonationBusiness.GetCauseOfDonationById(id);
            if (ls.Count > 0)
            {
                return View(ls[0]);
            }
            return null;
        }

        //
        // GET: /Admin/CauseOfDonation/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/CauseOfDonation/Create

        [HttpPost]
        public ActionResult CreateProcess(FormCollection frm)
        {
            int kt = 0;
            try
            {
                int isField = 0;
                if (frm["cbIsFieldOfProgram"].ToString().Contains("rmb"))
                {
                    isField = 1;
                }
                // TODO: Add insert logic here
                Models.CauseOfDonation ad = new Models.CauseOfDonation()
                {
                    Description = frm["Description"],
                    IsFieldOfPrograms = isField,
                    IsDeleted = 0
                };

                kt = CauseOfDonationBusiness.AddCauseOfDonation(ad);

            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("ListCause", "CauseOfDonation", new { add = "success" });
            }
            else
            {
                return RedirectToAction("ListCause", "CauseOfDonation", new { add = "error" });
            }
        }

        //
        // GET: /Admin/CauseOfDonation/Edit/5

        public ActionResult Edit(int id)
        {
            List<CauseOfDonation> ls = CauseOfDonationBusiness.GetCauseOfDonationById(id);
            if (ls.Count > 0)
            {
                return View(ls[0]);
            }
            return null;
        }

        //
        // POST: /Admin/CauseOfDonation/Edit/5

        [HttpPost]
        public ActionResult EditProcess(int id, FormCollection frm)
        {
            int kt = 0;
            try
            {
                int isField = 0;
                if (frm["cbIsFieldOfProgram"].ToString().Contains("rmb"))
                {
                    isField = 1;
                }
                // TODO: Add insert logic here
                Models.CauseOfDonation ad = new Models.CauseOfDonation()
                {
                    Id=int.Parse(frm["Id"]),
                    Description = frm["Description"],
                    IsFieldOfPrograms = isField,
                    IsDeleted = int.Parse(frm["IsDeleted"])
                };

                kt = CauseOfDonationBusiness.EditCauseOfDonation(ad);

            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("ListCause", "CauseOfDonation", new { update = "success" });
            }
            else
            {
                return RedirectToAction("ListCause", "CauseOfDonation", new { update = "error" });
            }
        }

        //
        // GET: /Admin/CauseOfDonation/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                int kt = CauseOfDonationBusiness.DeleteCauseOfDonation(id);
                if (kt > 0)
                {
                    return RedirectToAction("ListCause", "CauseOfDonation", new { delete = "success" });
                }
                else
                {
                    return RedirectToAction("ListCause", "CauseOfDonation", new { delete = "error" });
                }
            }
            catch
            {
                return RedirectToAction("ListCause", "CauseOfDonation", new { delete = "error" });
            }
        }

     
        [HttpPost]
        public JsonResult CheckExist(string description, int? id)
        {
            bool check = false;
            List<Models.CauseOfDonation> ls = CauseOfDonationBusiness.CheckCauseExisted(description, id);
            if (ls.Count > 0)
            {
                check = true;
            }
            return Json(check == false);
        }


    }
}
