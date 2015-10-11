using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLogicLayer;

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

        public ActionResult ListProgram(string type)
        {
            ViewData["type"] = type;
            List<Models.ImageGallery> lsTopic = ImageGalleryBusiness.GetImageTopicPrograms();
            ViewData["lsTopicPrograms"] = lsTopic;

            List<Models.Programs> ls = ProgramsBusiness.GetAllPrograms();
            if (type == "upcoming")
            {
                ls = ls.Where(d => d.Status == 0).ToList();
            }
            else if (type == "recent")
            {
                ls = ls.Where(d => d.Status == 1).ToList();
            }
            else
            {
                ls = ls.Where(d => d.Status == 2).ToList();
            }
            return View(ls);
        }

        public ActionResult PartialViewProgram(string type)
        {
            List<Models.ImageGallery> lsTopic = ImageGalleryBusiness.GetImageTopicPrograms();
            ViewData["lsTopicPrograms"] = lsTopic;
            ViewData["type"] = type;

            List<Models.Programs> ls = ProgramsBusiness.GetAllPrograms();
            if (type == "upcoming")
            {
                ls = ls.Where(d => d.Status == 0).Take(3).ToList();
            }
            else if (type == "recent")
            {
                ls = ls.Where(d => d.Status == 1).Take(3).ToList();
            }
            else
            {
                ls = ls.Where(d => d.Status == 2).Take(3).ToList();
            }

            return PartialView(ls);
        }

        public ActionResult ProgramDetail(int id)
        {
            List<Models.ImageGallery> lsTopic = ImageGalleryBusiness.GetImageTopicPrograms();
            foreach (var item in lsTopic)
            {
                if (item.ProgramId == id)
                {

                    ViewData["ls1"] = item;
                }
            }
            if (Session["user_login"] != null)
            {

                List<Models.Programs> ls = ProgramsBusiness.GetProgramsById(id);
                ViewData["program"] = ls[0];
                Models.Member ad = Session["user_login"] as Models.Member;
                Models.Message msg = new Models.Message();
                msg.SenderName = ad.FullName;
                msg.SenderEmail = ad.Email;
                return View(msg);

            }
            else
            {
                List<Models.Programs> ls = ProgramsBusiness.GetProgramsById(id);
                ViewData["program"] = ls[0];
                return View();
            }
            

            
            
            
        }

    }
}
