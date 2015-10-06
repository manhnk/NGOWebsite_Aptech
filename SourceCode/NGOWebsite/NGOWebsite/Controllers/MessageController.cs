using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using Models;

namespace NGOWebsite.Controllers
{
    public class MessageController : Controller
    {
        //
        // GET: /Message/

        public ActionResult Message()
        {
            return View();
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
                    SenderName = frm["SenderName"],
                    SenderEmail = frm["SenderEmail"],
                    Messages = frm["Messages"],
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
                return RedirectToAction("Message", "Message", new { add = "success" });
            }
            else
            {
                return RedirectToAction("Message", "Message", new { add = "error" });
            }
        }
    }
}
