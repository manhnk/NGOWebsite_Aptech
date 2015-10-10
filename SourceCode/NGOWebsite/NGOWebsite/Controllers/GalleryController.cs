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
            List<Models.ImageGallery> lsOthers = ImageGalleryBusiness.GetImageOthers();
            ViewData["lsProgram"] = ls;
            ViewData["lsOthers"] = lsOthers;
            foreach (var item in ls)
            {
                List<Models.ImageGallery> ls1 = ImageGalleryBusiness.GetImageGalleryByProgram(item.Id);
            }
            //if (ls1.Count > 0)
            //{
            //    ViewData["program"] = ls1[0];
            //}
            return View();
        }

    }
}
