﻿using System;
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
            List<Models.ImageGallery> ls = ImageGalleryBusiness.GetImageGalleryById(id);
            if (ls.Count > 0)
            {
                return View(ls[0]);
            }
            return View();
        }

        //
        // GET: /Admin/ImageGallery/Create

        public ActionResult Create(int? proId)
        {
            if (proId != null)
            {
                List<Programs> ls = ProgramsBusiness.GetProgramsById((int)proId);
                ViewData["pro"] = ls[0];
            }
            List<Models.Programs> lsPro = BusinessLogicLayer.ProgramsBusiness.GetAllPrograms();
            ViewData["Program"] = new SelectList(lsPro, "Id", "Name");
            return View();
        }

        //
        // POST: /Admin/ImageGallery/Create

        [HttpPost]
        public ActionResult CreateProcess(FormCollection frm, HttpPostedFileBase[] ImagePath)
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

                    Nullable<int> isTopicImg = null;

                    Nullable<int> proId = null;
                    if (frm["ProgramId"] != "")
                    {
                        proId = int.Parse(frm["ProgramId"]);
                        List<ImageGallery> lsImg = ImageGalleryBusiness.GetImageTopic((int)proId);
                        if (lsImg.Count == 0)//if program doesn't has any image then set topic image =1
                        {
                            isTopicImg = 1;
                        }
                    }

                    Models.ImageGallery ad = new Models.ImageGallery()
                    {
                        ImagePath = filepathtosave,
                        ProgramId = proId,
                        IsTopicImage = isTopicImg,
                        Description = frm["Description"]
                    };

                    int check = ImageGalleryBusiness.AddImageGallery(ad);
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
            List<Models.Programs> lsPro = BusinessLogicLayer.ProgramsBusiness.GetAllPrograms();
            ViewData["Program"] = new SelectList(lsPro, "Id", "Name");
            List<ImageGallery> ls = ImageGalleryBusiness.GetImageGalleryById(id);
            if (ls.Count > 0)
            {
                return View(ls[0]);
            }
            return View();
        }

        //
        // POST: /Admin/ImageGallery/Edit/5

        [HttpPost]
        public ActionResult EditProcess(int id, FormCollection frm)
        {
            int kt = 0;
            try
            {
                Nullable<int> isTopicImg = null;

                Nullable<int> proId = null;
                if (frm["ProgramId"] != "")
                {
                    proId = int.Parse(frm["ProgramId"]);
                }

                if (frm["cbIsTopicImage"].ToString().Contains("rmb"))
                {
                    isTopicImg = 1;
                }

                Models.ImageGallery ad = new Models.ImageGallery()
                {
                    Id=int.Parse(frm["Id"]),
                    ImagePath=frm["ImagePath"],
                    ProgramId = proId,
                    IsTopicImage = isTopicImg,
                    Description = frm["Description"]
                };

                int check = ImageGalleryBusiness.EditImageGallery(ad);
                if (check > 0)
                {
                    kt++;
                }
            }
            catch
            {
                kt = 0;
            }

            if (kt>0)
            {
                return RedirectToAction("Index", "ImageGallery", new { update = "success" });
            }
            else
            {
                return RedirectToAction("Index", "ImageGallery", new { update = "error" });
            }
        }

        //
        // GET: /Admin/ImageGallery/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //

        public ActionResult ProgramImages(int id)
        {
            List<Models.ImageGallery> ls = ImageGalleryBusiness.GetImageGalleryByProgram(id);
            if (ls.Count > 0)
            {
                ViewData["program"] = ls[0];
                return View(ls);
            }
            return View();
        }


    }
}
