using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLogicLayer;
using System.Net.Mail;
using System.Net;

namespace NGOWebsite.Controllers
{
    public class DonateController : Controller
    {
        //
        // GET: /Donate/

        public ActionResult Donate(int? proId)
        {
            if (proId != null)
            {
                Programs p=ProgramsBusiness.GetProgramsById((int)proId)[0];
                ViewData["program"] = p;
            }
            List<CauseOfDonation> lsCause = CauseOfDonationBusiness.GetAllCauseOfDonation();
            ViewData["lsCause"] = new SelectList(lsCause, "Id", "Description");
            return View();
        }

        [HttpPost]
        public ActionResult DonateProcess(FormCollection frm)
        {
            int kt = 0;
            try
            {
                int? cause = null;
                int? program = null;
                if (frm["ProgramId"] != null && frm["ProgramId"] != "")
                {
                    program = int.Parse(frm["ProgramId"]);
                }
                if (frm["CauseOfDonation"] != null && frm["CauseOfDonation"] != "")
                {
                    cause = int.Parse(frm["CauseOfDonation"]);
                }

                Donation dn = new Donation()
                {
                    FullNameDonator = frm["FullNameDonator"],
                    GenderDonator = frm["GenderDonator"],
                    EmailDonator = frm["EmailDonator"],
                    CauseId = cause,
                    ProgramId = program,
                    DateOfDonation= DateTime.Today.Date,
                    Amount=double.Parse(frm["Amount"]),
                    CreditType = frm["CreditType"],
                    CardNumber = frm["CardNumber"],
                };

                kt = DonationBusiness.AddDonation(dn);
            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("Donate", "Donate", new { add = "success" });
            }
            else
            {
                return RedirectToAction("Donate", "Donate", new { add = "error" });
            }
        }

        [HttpPost]
        public ActionResult SendEmail(FormCollection frm)
        {
            int kt = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    string url = HttpContext.Request.Url.AbsoluteUri;
                    url=url.Substring(0,url.IndexOf("Donate/"));

                    string from = "ngowebsite4@gmail.com";
                    string to = frm["EmailDonator"];
                    using (MailMessage mail = new MailMessage(from, to))
                    {
                        mail.IsBodyHtml = true;
                        mail.Subject = "From N.G.O Website";
                        mail.Body = string.Format("Dear Sir/Madam,<br/><br/>A your friend has invited join with us ! Welcome to NGO Website !<br/><a href='{0}'>NGO Webiste</a> <br/><br/>Thanks and regards,<br/>N.G.O",url);
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential networkCre = new NetworkCredential(from, "project4");
                        //smtp.UseDefaultCredentials = false;
                        smtp.Credentials = networkCre;
                        smtp.Port = 25;
                        smtp.Send(mail);
                    }

                }
                kt = 1;
            }
            catch
            {
                kt = 0;
            }
            if (kt > 0)
            {
                return RedirectToAction("Donate", "Donate", new { send = "success" });
            }
            else
            {
                return RedirectToAction("Donate", "Donate", new { send = "error" });
            }
        }
    }
}
