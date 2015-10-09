using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLogicLayer;

namespace NGOWebsite.Areas.Admin.Controllers
{
    public class ProgramsADController : Controller
    {
        //
        // GET: /Admin/ProgramsAD/

        public ActionResult ListProgram()
        {
            List<Programs> ls = ProgramsBusiness.GetAllPrograms();
            return View(ls);
        }

        //
        // GET: /Admin/ProgramsAD/Details/5

        public ActionResult Details(int id)
        {
            Programs p = ProgramsBusiness.GetProgramsById(id)[0];
            List<ImageGallery> ls = ImageGalleryBusiness.GetImageGalleryByProgram(id);
            ViewData["image"] = ls.Count;

            return View(p);
        }


        [HttpPost]
        public JsonResult CheckNameExisted(string name, int? id)
        {
            bool check = false;

            int kt = ProgramsBusiness.CheckNameExisted(name, id);
            if (kt > 0)
            {
                check = true;
            }
            return Json(check == false);
        }

        //
        // GET: /Admin/ProgramsAD/Create

        public ActionResult Create()
        {
            List<CauseOfDonation> lsCause = CauseOfDonationBusiness.GetFieldOfPrograms();
            ViewData["lsCause"] = new SelectList(lsCause, "Id", "Description");
            return View();
        }

        //
        // POST: /Admin/ProgramsAD/Create

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreateProcess(FormCollection frm)
        {
            int kt = 0;
            try
            {
                Programs pro = new Programs()
                {
                    Name = frm["Name"],
                    CauseId = int.Parse(frm["CauseId"]),
                    Status = 0,
                    Contents = frm["Contents"]
                };

                kt = ProgramsBusiness.AddPrograms(pro);

            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("ListProgram", "ProgramsAD", new { add = "success" });
            }
            else
            {
                return RedirectToAction("ListProgram", "ProgramsAD", new { add = "error" });
            }
        }

        //
        // GET: /Admin/ProgramsAD/Edit/5

        public ActionResult Edit(int id)
        {

            List<ImageGallery> ls = ImageGalleryBusiness.GetImageGalleryByProgram(id);
            ViewData["image"] = ls.Count;

            List<CauseOfDonation> lsCause = CauseOfDonationBusiness.GetFieldOfPrograms();
            ViewData["lsCause"] = new SelectList(lsCause, "Id", "Description");

            List<Status> lsStatus = new List<Status>()
            {
                new Status(){value=0,text="Upcoming"},
                new Status(){value=1,text="Recent"},
                new Status(){value=2,text="Complete"},
            };
            ViewData["lsStatus"] = new SelectList(lsStatus, "value", "text");

            Programs p = ProgramsBusiness.GetProgramsById(id)[0];
            return View(p);
        }

        //
        // POST: /Admin/ProgramsAD/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditProcess(int id, FormCollection frm)
        {
            int kt = 0;
            try
            {
                Programs pro = new Programs()
                {
                    Id = int.Parse(frm["Id"]),
                    Name = frm["Name"],
                    CauseId = int.Parse(frm["CauseId"]),
                    Status = int.Parse(frm["Status"]),
                    Contents = frm["Contents"]
                };

                kt = ProgramsBusiness.EditPrograms(pro);

            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("ListProgram", "ProgramsAD", new { update = "success" });
            }
            else
            {
                return RedirectToAction("ListProgram", "ProgramsAD", new { update = "error" });
            }
        }

        //
        // GET: /Admin/ProgramsAD/Delete/5

        public ActionResult Delete(int id)
        {
            int kt = 0;
            try
            {
                kt = ProgramsBusiness.DeletePrograms(id);
            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("ListProgram", "ProgramsAD", new { delete = "success" });
            }
            else
            {
                return RedirectToAction("ListProgram", "ProgramsAD", new { delete = "error" });
            }
        }


    }

    public class Status
    {
        public int value { get; set; }
        public string text { get; set; }
    }
}
