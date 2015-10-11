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

            List<Models.Programs> lsPro = BusinessLogicLayer.ProgramsBusiness.GetAllPrograms();
            ViewData["Program"] = new SelectList(lsPro, "Id", "Name");
            if (Session["user_login"] != null)
            {
                Models.Member ad = Session["user_login"] as Models.Member;
                Models.Message msg = new Models.Message();
                msg.SenderName = ad.FullName;
                msg.SenderEmail = ad.Email;
                return View(msg);

            }
            else
            {
                return View();

            }
        }
        // POST: /Admin/Message/Create

        [HttpPost]
        public ActionResult AddMsgProcess(FormCollection frm)
        {
            int kt = 0;
                int? programId = null;

            try
            {
                if (frm["ProgramId"] != null && frm["ProgramId"] != "")
                {
                    programId = int.Parse(frm["programId"]);
                }
                // TODO: Add insert logic here
                Models.Message ad = new Models.Message()
                {
                    ProgramId = programId,
                    SenderName = frm["SenderName"],
                    SenderEmail = frm["SenderEmail"],
                    Messages = frm["Messages"],
                    Status = 0,
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
                if (frm["sender"] != null)
                {
                    return RedirectToAction("ProgramDetail", "Programs", new { add = "success", @id = programId });
                }
                else
                    return RedirectToAction("Message", "Message", new { add = "success" });
            }
            else
            {
                if (frm["sender"] != null)
                {
                    return RedirectToAction("ProgramDetail", "Programs", new { add = "error", @id = programId});
                }
                else
                    return RedirectToAction("Message", "Message", new { add = "error" });
            }
        }
    }
}
