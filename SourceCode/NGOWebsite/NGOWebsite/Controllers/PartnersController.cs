using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLogicLayer;

namespace NGOWebsite.Controllers
{
    public class PartnersController : Controller
    {
        //
        // GET: /Partners/

        // Show partners
        [AllowAnonymous]
        public ActionResult Partners()
        {
            List<Models.Partners> ls = PartnersBusiness.GetAllPartners();
            return View();
        }

    }
}
