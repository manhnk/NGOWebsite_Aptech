using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLogicLayer;

namespace NGOWebsite.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        //
        // GET: /Admin/Home/

        public ActionResult Index()
        {
            //count member
            List<Member> lsMember = MemberBusiness.GetAllMember();
            ViewData["Member"] = lsMember.Count;

            //count Programs
            List<Programs> lsPro = ProgramsBusiness.GetAllPrograms();
            ViewData["Program"] = lsPro.Count;

            //count new mss program
            List<Message> lsMssPro = MessageBusiness.GetProgramMessage();
            int count = lsMssPro.Sum(d => d.TotalNewMessage);
            ViewData["MssPro"] = count;

            //count new mss others
            List<Message> lsMssOther = MessageBusiness.GetOtherMessage().Where(d => d.Status==0).ToList();
            ViewData["MssOther"] = lsMssOther.Count;

            //total amount donation programs
            List<Donation> lsDonationPro = DonationBusiness.GetDonationByProgramOrCause("program");
            double amountPro = lsDonationPro.Sum(d => d.TotalAmount);
            ViewData["amountPro"] = amountPro;

            //total amount donation Cause
            List<Donation> lsDonationCause = DonationBusiness.GetDonationByProgramOrCause("cause");
            double amountCause = lsDonationCause.Sum(d => d.TotalAmount);
            ViewData["amountCause"] = amountCause;

            ViewData["totalAmount"] = amountPro + amountCause;

            return View();
        }

        //
        // GET: /Admin/Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Home/Delete/5

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
