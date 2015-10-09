using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLogicLayer;

namespace NGOWebsite.Controllers
{
    public class InformationsController : Controller
    {
        //
        // GET: /Information/

        

        public ActionResult ReadAboutUs()
        {
            return View();
        }
        public ActionResult WhatWeDo()
        {
            return View();
        }
        public ActionResult OurMission()
        {
            return View();
        }
        public ActionResult OurTeam()
        {
            return View();
        }
        public ActionResult OurAchievements()
        {
            return View();
        }
        public ActionResult OurSupporters()
        {
            return View();
        }
    }
}
