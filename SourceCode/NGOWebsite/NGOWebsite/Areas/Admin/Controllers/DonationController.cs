using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NGOWebsite.Areas.Admin.Controllers
{
    public class DonationController : Controller
    {
        //
        // GET: /Admin/Donation/

        public ActionResult Index()
        {
            return View();
        }

    }
}
