using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLogicLayer;

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

    }
}
