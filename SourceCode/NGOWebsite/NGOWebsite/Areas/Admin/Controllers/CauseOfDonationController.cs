using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using Models;

namespace NGOWebsite.Areas.Admin.Controllers
{
    public class CauseOfDonationController : Controller
    {
        //
        // GET: /Admin/CauseOfDonation/

        public ActionResult ListCause()
        {
            List<CauseOfDonation> ls= CauseOfDonationBusiness.GetAllCauseOfDonation();
            return View(ls);
        }

        //
        // GET: /Admin/CauseOfDonation/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/CauseOfDonation/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/CauseOfDonation/Create

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
        // GET: /Admin/CauseOfDonation/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/CauseOfDonation/Edit/5

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
        // GET: /Admin/CauseOfDonation/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/CauseOfDonation/Delete/5

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
