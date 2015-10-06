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
    }
}
