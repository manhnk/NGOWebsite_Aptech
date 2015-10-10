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
            List<Models.ImageGallery> lsTopic = ImageGalleryBusiness.GetImageTopicPrograms();
            ViewData["lsTopicPrograms"] = lsTopic;
            
            List<Models.Programs> ls = ProgramsBusiness.GetAllPrograms();
            if (ls.Count > 0)
            {
                return View(ls);
            }
            else return null;

        }
        public ActionResult RecentProgram(int id)
        {
            List<Models.ImageGallery> lsTopic = ImageGalleryBusiness.GetImageTopicPrograms();
            foreach (var item in lsTopic)
            {
                if (item.ProgramId == id)
                {
                    
                    ViewData["ls1"] = item;
                }
            }
            
            List<Models.Programs> ls = ProgramsBusiness.GetProgramsById(id);
            if (ls.Count > 0)
            {
                return View(ls[0]);
            }
            else
            {
                return null;
            }
        }

    }
}
