using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NGOWebsite.Controllers
{
    public class InformationController : Controller
    {
        //
        // GET: /Information/

        public ActionResult WhatWeDo()
        {
            return View();
        }
        public ActionResult Help()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Stories()
        {
            return View();
        }
    }
}
