using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLogicLayer;
using System.Net.Mail;
using System.Net;

namespace NGOWebsite.Areas.Admin.Controllers
{
    public class MessagesController : Controller
    {
        //
        // GET: /Admin/Messages/

        public ActionResult ListMessage(string type)
        {
            if (type == "pro")
            {
                List<Message> ls = MessageBusiness.GetProgramMessage();
                return View("ListProgramMessage", ls);
            }
            else
            {
                List<Message> ls = MessageBusiness.GetOtherMessage();
                return View("ListOtherMessage", ls);
            }
        }

        public ActionResult ProgramMessageDetail(int proId)
        {
            List<Message> ls = MessageBusiness.GetMessageByProgram(proId);
            return View(ls);
        }

        //
        // GET: /Admin/Messages/Details/5

        public ActionResult Details(int id, string flag)
        {
            Message mes = MessageBusiness.GetMessageById(id)[0];
            if (mes.Status == 0)
            {
                mes.Status = 1;

                int kt = MessageBusiness.EditMessage(mes);
            }
            ViewData["flag"] = flag;
            return View(mes);
        }


        //
        // GET: /Admin/Messages/Delete/5

        public ActionResult Delete(int id, string flag)
        {
            int kt = 0;
            Message mes = MessageBusiness.GetMessageById(id)[0];
            try
            {
                kt = MessageBusiness.DeleteMessage(id);
            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                if (flag == "program")
                {
                    return RedirectToAction("ProgramMessageDetail", "Messages", new { delete = "success", proId = mes.ProgramId });
                }
                else
                {
                    return RedirectToAction("ListMessage", "Messages", new { delete = "success", flag = "other" });
                }
            }
            else
            {
                if (flag == "program")
                {
                    return RedirectToAction("ProgramMessageDetail", "Messages", new { delete = "error", proId = mes.ProgramId });
                }
                else
                {
                    return RedirectToAction("ListMessage", "Messages", new { delete = "error", flag = "other" });
                }
            }

        }


        public ActionResult Reply(int id, string flag)
        {
            Session["flag"] = flag;
            Message ms = MessageBusiness.GetMessageById(id)[0];
            return View(ms);
        }

        [HttpPost]
        public ActionResult ReplyProcess(FormCollection frm)
        {
            int kt = 0;
            try
            {
                if (ModelState.IsValid)
                {

                    string from = "ngowebsite4@gmail.com";
                    string to = frm["SenderEmail"];
                    using (MailMessage mail = new MailMessage(from, to))
                    {
                        mail.IsBodyHtml = true;
                        mail.Subject = "[Reply] From N.G.O Website";
                        mail.Body = string.Format("Dear Mr/Mrs.{0},\r\n{1}", frm["SenderName"], frm["MessageReply"]);
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential networkCre = new NetworkCredential(from, "project4");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = networkCre;
                        smtp.Port = 25;
                        //smtp.Send(mail);
                    }

                }
                kt = 1;
            }
            catch
            {
                kt = 0;
            }

            int upt = 0;
            int mesId = int.Parse(frm["Id"]);
            Message ms = MessageBusiness.GetMessageById(mesId)[0];
            string flag = Session["flag"].ToString();

            if (kt == 1)
            {
                Models.Admin ad = Session["mvc_user"] as Models.Admin;
                ms.Status = 2;
                ms.ReplierId = ad.Id;
                upt = MessageBusiness.EditMessage(ms);

                if (flag == "program")
                {
                    return RedirectToAction("ProgramMessageDetail", "Messages", new { send = "success", proId = ms.ProgramId });
                }
                else
                {
                    return RedirectToAction("ListMessage", "Messages", new { send = "success", flag = "other" });
                }
            }
            else
            {
                if (flag == "program")
                {
                    return RedirectToAction("ProgramMessageDetail", "Messages", new { send = "error", proId = ms.ProgramId });
                }
                else
                {
                    return RedirectToAction("ListMessage", "Messages", new { send = "error", flag = "other" });
                }
            }




        }
    }
}
