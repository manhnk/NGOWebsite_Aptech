using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using Models;

namespace NGOWebsite.Controllers
{
    public class InformationssController : Controller
    {
        //
        // GET: /Informationss/

        public ActionResult OurAchievements()
        {
            List<Models.Informations> about = InformationsBusiness.GetInformationsById(5);
            return View(about);
        }
        public ActionResult OurMission()
        {
            List<Models.Informations> about = InformationsBusiness.GetInformationsById(2);
            return View(about);
        }
        public ActionResult OurSupporters()
        {
            List<Models.Informations> about = InformationsBusiness.GetInformationsById(6);
            return View(about);
        }
        public ActionResult OurTeam()
        {
            //List<Models.Informations> about = InformationsBusiness.GetInformationsById(3);
            List<Models.Member> ls = MemberBusiness.GetAllMember().Where(d => d.IsMemberOfTeam == 1).ToList();
            return View(ls);
        }
        public ActionResult ReadAboutUs()
        {
            List<Models.Informations> about = InformationsBusiness.GetInformationsById(7);
            return View(about);
        }
        public ActionResult WhatWeDo()
        {
            List<Models.Informations> about = InformationsBusiness.GetInformationsById(1);
            return View(about);
        }

        public ActionResult NewsDetail(int id)
        {
            Informations info = InformationsBusiness.GetInformationsById(id)[0];
            ViewData["info"] = info;
            Random rnd=new Random();
            List<Informations> ls = InformationsBusiness.GetAllInformations().Where(d => d.ParentId == null).OrderBy(q => Guid.NewGuid()).Take(10).ToList();
            ViewData["lsRandom"] = ls;

            return View();
        }
    }

   
}
