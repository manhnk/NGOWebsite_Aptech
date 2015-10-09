using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLogicLayer;

namespace NGOWebsite.Areas.Admin.Controllers
{
    public class PartnersADController : Controller
    {
        //
        // GET: /Admin/Partners/

        public ActionResult ListPartner()
        {
            List<Partners> ls = PartnersBusiness.GetAllPartners();
            return View(ls);
        }

        //
        // GET: /Admin/Partners/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Partners/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Partners/Create

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreateProcess(FormCollection frm)
        {
            int kt = 0;
            try
            {
                string filepathtosave ="";
                if (Request.Files[0].ContentLength>0)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    /*Geting the file name*/
                    string filename = System.IO.Path.GetFileName(file.FileName);
                    /*Saving the file in server folder*/
                    file.SaveAs(Server.MapPath(@"~/Content/ImageUpload/Partners/" + filename));
                    filepathtosave= "Content/ImageUpload/Partners/" + filename;

                }
                else
                {
                    filepathtosave = "Content/ImageUpload/Partners/partners.jpg";
                }

                Models.Partners ad = new Models.Partners()
                {
                    Name = frm["Name"],
                    Address = frm["Address"],
                    Email = frm["Email"],
                    Profile = frm["Profile"],
                    Phone = frm["Phone"],
                    Logo = filepathtosave,
                };

                int check = PartnersBusiness.AddPartners(ad);
                if (check > 0)
                {
                    kt++;
                }

            }
            catch
            {
                kt = 0;
            }

            if (kt >0)
            {
                return RedirectToAction("ListPartner", "PartnersAD", new { add = "success" });
            }
            else
            {
                return RedirectToAction("ListPartner", "PartnersAD", new { add = "error" });
            }
        }

        
        [HttpPost]
        public JsonResult CheckNameExist(string name, int? id)
        {
            bool check = false;

            List<Models.Partners> ls = PartnersBusiness.CheckPartnerExisted(name, id);
            if (ls.Count > 0)
            {
                check = true;
            }
            return Json(check == false);
        }

        //
        // GET: /Admin/Partners/Edit/5

        public ActionResult Edit(int id)
        {
            List<Partners> ls = PartnersBusiness.GetPartnersById(id);
            return View(ls[0]);
        }

        //
        // POST: /Admin/Partners/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditProcess(int id, FormCollection frm)
        {
            int kt = 0;
            try
            {
                string filepathtosave = "";
                if (Request.Files[0].ContentLength > 0)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    /*Geting the file name*/
                    string filename = System.IO.Path.GetFileName(file.FileName);
                    /*Saving the file in server folder*/
                    file.SaveAs(Server.MapPath(@"~/Content/ImageUpload/Partners/" + filename));
                    filepathtosave = "Content/ImageUpload/Partners/" + filename;
                }
                else
                {
                    filepathtosave = frm["Logo"];
                }

                Models.Partners ad = new Models.Partners()
                {
                    Id=int.Parse(frm["Id"]),
                    Name = frm["Name"],
                    Address = frm["Address"],
                    Email = frm["Email"],
                    Profile = frm["Profile"],
                    Phone = frm["Phone"],
                    Logo = filepathtosave,
                };

                int check = PartnersBusiness.EditPartners(ad);
                if (check > 0)
                {
                    kt++;
                }

            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("ListPartner", "PartnersAD", new { update = "success" });
            }
            else
            {
                return RedirectToAction("ListPartner", "PartnersAD", new { update = "error" });
            }
        }

        //
        // GET: /Admin/Partners/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Partners/Delete/5

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
