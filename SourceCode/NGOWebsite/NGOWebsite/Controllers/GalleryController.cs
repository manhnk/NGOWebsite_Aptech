using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLogicLayer;

namespace NGOWebsite.Controllers
{
    public class GalleryController : Controller
    {
        //
        // GET: /Gallery/

        public ActionResult Gallery()
        {
            List<Models.ImageGallery> ls = ImageGalleryBusiness.GetProgramImage();
            List<Models.ImageGallery> lsTopic = ImageGalleryBusiness.GetImageTopicPrograms();
            List<Models.ImageGallery> lsOthers = ImageGalleryBusiness.GetImageOthers();
            ViewData["lsProgram"] = ls;
            ViewData["lsTopicPrograms"] = lsTopic;
            ViewData["lsOthers"] = lsOthers;
            return View();
        }
    }
}
