﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NGOWebsite.Controllers
{
    public class ProgramsController : Controller
    {
        //
        // GET: /Programs/

        public ActionResult Programs()
        {
            return View();
        }
        public ActionResult RecentProgram()
        {
            return View();
        }

    }
}