using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLogicLayer;

namespace NGOWebsite.Areas.Admin.Controllers
{
    public class DonationController : Controller
    {
        //
        // GET: /Admin/Donation/

        public ActionResult DonatioPartialView(string type)
        {
            ViewData["Type"] = type;
            List<Donation> ls = DonationBusiness.GetDonationByProgramOrCause(type);
            return PartialView(ls);
        }

        public ActionResult DonationForPrograms()
        {
            ViewData["Type"] = "program";
            List<Donation> ls = DonationBusiness.GetDonationByProgramOrCause("program");
            if (ls.Count > 0)
            {
                return View("Donation",ls);
            }
            return View();
        }

        public ActionResult DonationForOthers()
        {
            ViewData["Type"] = "cause";
            List<Donation> ls = DonationBusiness.GetDonationByProgramOrCause("cause");
            if (ls.Count > 0)
            {
                return View("Donation",ls);
            }
            return View();
        }

        public ActionResult DonationDetails(string flag,int id)
        {
            List<Donation> ls = DonationBusiness.GetDonation(flag,id);
            
            if (ls.Count > 0)
            {
                ViewData["Type"] = flag;
                if (flag == "program")
                {
                    ViewData["Name"] = ls[0].Program;
                }
                else
                {
                    ViewData["Name"] = ls[0].CauseOfDonation;
                }
                return View(ls);
            }
            return View();
        }


        public ActionResult Details(int id,string flag)
        {
            List<Donation> ls = DonationBusiness.GetDonationById(id);

            if (ls.Count > 0)
            {
                ViewData["Type"] = flag;
                return View(ls[0]);
            }
            return View();
        }
    }
}
