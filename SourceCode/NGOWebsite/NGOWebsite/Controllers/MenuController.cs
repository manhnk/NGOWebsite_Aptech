using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using Models;

namespace NGOWebsite.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/
        [ChildActionOnly]
        public ActionResult Index()
        {
            List<Models.Menu> ls = MenuBusiness.GetAllMenu();
            return PartialView(ls) ;

        }


    }
}
