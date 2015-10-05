using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLogicLayer;

namespace NGOWebsite.Areas.Admin.Controllers
{
    public class ImageGalleryController : Controller
    {
        //
        // GET: /Admin/ImageGallery/

        public ActionResult Index()
        {
            List<Models.ImageGallery> ls = ImageGalleryBusiness.GetProgramImage();
            List<Models.ImageGallery> lsTopic = ImageGalleryBusiness.GetImageTopicPrograms();
            List<Models.ImageGallery> lsOthers = ImageGalleryBusiness.GetImageOthers();
            ViewData["lsProgram"] = ls;
            ViewData["lsTopicPrograms"] = lsTopic;
            ViewData["lsOthers"] = lsOthers;
            return View();
        }

        //
        // GET: /Admin/ImageGallery/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/ImageGallery/Create

        public ActionResult Create()
        {
            List<Models.Programs> lsPro = BusinessLogicLayer.ProgramsBusiness.GetAllPrograms();
            ViewData["Program"] = new SelectList(lsPro, "Id", "Name");
            return View();
        }

        //
        // POST: /Admin/ImageGallery/Create

        [HttpPost]
        public ActionResult CreateProcess(FormCollection frm,HttpPostedFileBase[] ImagePath)
        {
            int kt = 0;
            try
            {
                foreach (HttpPostedFileBase file in ImagePath)
                {
                    /*Geting the file name*/
                    string filename = System.IO.Path.GetFileName(file.FileName);
                    /*Saving the file in server folder*/
                    file.SaveAs(Server.MapPath(@"~/ImageUpload/" + filename));
                    string filepathtosave = "ImageUpload/" + filename;

                    Nullable<int> proId = null;
                    if (frm["ProgramId"] != "")
                    {
                        proId=int.Parse(frm["ProgramId"]);
                    }

                    Nullable<int> isTopicImg = null;
                    if (proId != null && kt == 0)
                    {
                        isTopicImg = 1;
                    }
                    Models.ImageGallery ad = new Models.ImageGallery()
                    {
                        ImagePath=filepathtosave,
                        ProgramId=proId,
                        IsTopicImage=isTopicImg,
                        Description=frm["Description"]
                    };

                    int check= ImageGalleryBusiness.AddImageGallery(ad);
                    if (check > 0)
                    {
                        kt++;
                    }
                }
                
            }
            catch
            {
                kt = 0;
            }

            if (kt == ImagePath.Count())
            {
                return RedirectToAction("Index", "ImageGallery", new { add = "success" });
            }
            else
            {
                return RedirectToAction("Index", "ImageGallery", new { add = "error" });
            }
        }

        //
        // GET: /Admin/ImageGallery/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/ImageGallery/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/ImageGallery/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/ImageGallery/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
