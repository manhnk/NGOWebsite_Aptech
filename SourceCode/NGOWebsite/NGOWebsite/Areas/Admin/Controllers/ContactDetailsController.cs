using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using Models;

namespace NGOWebsite.Areas.Admin.Controllers
{
    public class ContactDetailsController : Controller
    {
        //
        // GET: /Admin/ContactDetails/

        public ActionResult ListContact()
        {
            List<ContactDetails> ls = ContactsBusiness.GetAllContactDetails();
            return View(ls);
        }

        public ActionResult Details(int id)
        {
            List<ContactDetails> ls = ContactsBusiness.GetContactDetailsById(id);
            if (ls.Count > 0)
            {
                return View(ls[0]);
            }
            return null;
        }

        //
        // GET: /Admin/ContactDetails/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/ContactDetails/Create

        [HttpPost]
        public ActionResult CreateProcess(FormCollection frm)
        {
            int kt = 0;
            try
            {
                // TODO: Add insert logic here
                Models.ContactDetails ad = new Models.ContactDetails()
                {
                    Address = frm["Address"],
                    Phone = frm["Phone"],
                    Email = frm["Email"]
                };

                kt = ContactsBusiness.AddContactDetails(ad);

            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("ListContact", "ContactDetails", new { add = "success" });
            }
            else
            {
                return RedirectToAction("ListContact", "ContactDetails", new { add = "error" });
            }
        }

        //
        // GET: /Admin/ContactDetails/Edit/5

        public ActionResult Edit(int id)
        {
            List<ContactDetails> ls = ContactsBusiness.GetContactDetailsById(id);
            if (ls.Count > 0)
            {
                return View(ls[0]);
            }
            return null;
        }

        //
        // POST: /Admin/ContactDetails/Edit/5

        [HttpPost]
        public ActionResult EditProcess(int id, FormCollection frm)
        {
            int kt = 0;
            try
            {
           
                // TODO: Add insert logic here
                Models.ContactDetails ad = new Models.ContactDetails()
                {
                    Id = int.Parse(frm["Id"]),
                    Address = frm["Address"],
                    Phone = frm["Phone"],
                    Email = frm["Email"]
                };

                kt = ContactsBusiness.EditContactDetails(ad);

            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("ListContact", "ContactDetails", new { update = "success" });
            }
            else
            {
                return RedirectToAction("ListContact", "ContactDetails", new { update = "error" });
            }
        }

        //
        // GET: /Admin/ContactDetails/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                int kt = ContactsBusiness.DeleteContactDetails(id);
                if (kt > 0)
                {
                    return RedirectToAction("ListContact", "ContactDetails", new { delete = "success" });
                }
                else
                {
                    return RedirectToAction("ListContact", "ContactDetails", new { delete = "error" });
                }
            }
            catch
            {
                return RedirectToAction("ListContact", "ContactDetails", new { delete = "error" });
            }
        }


    }
}
