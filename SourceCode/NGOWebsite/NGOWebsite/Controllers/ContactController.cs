using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using Models;

namespace NGOWebsite.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/


        public ActionResult Contact()
        {

            List<Models.ContactDetails> ls = ContactsBusiness.GetAllContactDetails();
            if (ls.Count > 0)
            {
                return View(ls);
            }
            else return null;



        }
        // POST: /Admin/Message/Create

        [HttpPost]
        public ActionResult AddMsgProcess(FormCollection frm)
        {
            int kt = 0;
            try
            {
                // TODO: Add insert logic here
                Models.Message ad = new Models.Message()
                {
                    ProgramId = int.Parse(frm[""]),
                    SenderName = frm["Sname"],
                    SenderEmail = frm["Semail"],
                    Messages = frm["Message"],
                    Status = 0,
                    ReplierId = 0,
                    IsDeleted = 0
                };

                kt = MessageBusiness.AddMessage(ad);

            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("Contact", "Contact", new { add = "success" });
            }
            else
            {
                return RedirectToAction("Contact", "Contact", new { add = "error" });
            }
        }


    }
}
