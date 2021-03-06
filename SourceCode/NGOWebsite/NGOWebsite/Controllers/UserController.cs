﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using Models;

namespace NGOWebsite.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Home()
        {
            //Get slides for Slider
            List<ImageGallery> lsSlide = ImageGalleryBusiness.GetImageSlide();
            ViewData["slides"] = lsSlide;

            //Get partners
            List<Models.Partners> ls = PartnersBusiness.GetAllPartners();
            

            //Get Image for Home's programs
            List<Models.ImageGallery> lsTopic = ImageGalleryBusiness.GetImageTopicPrograms();
            ViewData["lsTopicPrograms"] = lsTopic;

            //Get recent programs which have status = 1
            List<Models.Programs> ls1 = ProgramsBusiness.GetAllPrograms().Where(d=> d.Status==1).OrderByDescending(d=>d.Id).Take(3).ToList();
            if (ls1.Count > 0)
            {
                ViewData["programs"] = ls1;
            }

            //Get NEWS from Information
            List<Models.Informations> ls2 = InformationsBusiness.GetAllInformations().Where(d=> d.ParentId==null).OrderByDescending(d=>d.Id).Take(5).ToList();
            
            if (ls2.Count > 0)
            {
                ViewData["infor"] = ls2;
            }

            return View(ls);
        }

        // Notify that User has joined our team!
        public ActionResult Notify()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CheckNameExist(string username, int? id)
        {
            bool check = false;

            List<Models.Member> ls = MemberBusiness.CheckUserExisted(username, id);
            if (ls.Count > 0)
            {
                check = true;
            }
            return Json(check == false);
        }

        [HttpPost]
        public JsonResult CheckPassword(string password)// name of paramter must be same with name of control 
        {
            bool check = false;
            int id = 0;
            if (Session["user_login"] != null)
            {
                Models.Member ad = Session["user_login"] as Models.Member;
                id = ad.Id;
            }


            List<Models.Member> ls = MemberBusiness.GetMemberById(id);
            if (ls.Count > 0)
            {
                if (ls[0].Password != DataAccessLayer.DataConnect.GetMd5Hash(password))
                {
                    check = true;
                }
            }
            return Json(check == false);
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Session["user_login"] != null)
            {
                return RedirectToAction("Home", "User");
            }
            else return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Home", "User");

        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult LoginProcess(FormCollection frm)
        {
            int check = 0;
            string user = frm["UserName"];
            string pass = frm["Password"];

            List<Models.Member> ls = MemberBusiness.CheckLogin(user, pass);

            if (ls.Count > 0)
            {
                Session["user_login"] = ls[0];

                HttpCookie c = new HttpCookie("user_ck");
                c.Values["user"] = user;
                c.Values["pass"] = pass;

                if (frm["cbRemember"].ToString().Contains("rmb"))
                {
                    c.Expires = DateTime.Now.AddDays(10);
                }
                else
                {
                    c.Expires = DateTime.Now.AddDays(-1);
                }
                Response.Cookies.Add(c);
                check = 1;

            }

            if (check == 1) return RedirectToAction("Home", "User");
            else
            {
                Models.Member mb = new Models.Member() { UserName = user, Password = pass };
                Session["draftUserAcc"] = mb;
                return RedirectToAction("Login", "User", new { error = "-1" });
            }


        }



        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterProcess(FormCollection frm)
        {

            int kt = 0;
            try
            {
                // TODO: Add insert logic here
                Models.Member ad = new Models.Member()
                {
                    UserName = frm["UserName"],
                    Password = frm["NewPassword"],
                    FullName = frm["FullName"],
                    Gender = frm["Gender"],
                    Phone = frm["Phone"],
                    Address = frm["Address"],
                    Email = frm["Email"],
                    IsMemberOfTeam = -1,
                    IsDeleted = 0,
                    Image = "Content/ImageUpload/Users/default.png"
                };
                // In error, need to be fixed!
                kt = MemberBusiness.AddMember(ad);

            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("Login", "User", new { regis = "success" });
            }
            else
            {
                return RedirectToAction("Register", "User", new { add = "error" });
            }

        }



        public ActionResult UserInfo()
        {
            Models.Member ad = new Models.Member();
            ad = (Member)Session["user_login"];
            if (Session["user_login"] != null)
            {
                List<Models.Member> ls = MemberBusiness.GetMemberById(ad.Id);
                if (ls.Count > 0)
                {
                    ViewData["img"] = ls[0].Image;
                    return View(ls[0]);
                }
                else return null;
            }
            else return null;

        }

        //
        // POST: /Member/Member/Edit/5

        [HttpPost]
        public ActionResult EditProcess(FormCollection frm)
        {
            int kt=0;
            try
            {
                string imagePath = "";
                if (Request.Files[0].ContentLength > 0)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    /*Geting the file name*/
                    string filename = System.IO.Path.GetFileName(file.FileName);
                    /*Saving the file in server folder*/
                    file.SaveAs(Server.MapPath(@"~/Content/ImageUpload/Users/" + filename));
                    imagePath = "Content/ImageUpload/Users/" + filename;
                }else{
                    imagePath=frm["Image"];
                }
                    Models.Member ad = new Models.Member()
                    {
                        Id = int.Parse(frm["Id"]),
                        UserName=frm["UserName"],
                        Password=frm["Password"],
                        Gender = frm["Gender"],
                        FullName = frm["FullName"],
                        Phone = frm["Phone"],
                        Address = frm["Address"],
                        Email = frm["Email"],
                        IsMemberOfTeam = int.Parse(frm["IsMemberOfTeam"]),
                        Image = imagePath
                    };
                    kt = MemberBusiness.EditMember(ad);

            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                    return RedirectToAction("UserInfo", "User", new { update = "success" });
            }
            else
            {
                return RedirectToAction("UserInfo", "User", new { update = "error" });
            }
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePasswordProcess(FormCollection frm)
        {
            int id = 0;
            if (Session["user_login"] != null)
            {
                Models.Member ad = Session["user_login"] as Models.Member;
                id = ad.Id;
            }
            int kt = 0;
            try
            {
                string newpass = frm["NewPassword"];

                kt = MemberBusiness.ChangePassword(id, newpass);

            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                Session.Abandon();
                return RedirectToAction("Login", "User", new { change = "success" });
            }
            else
            {

                return RedirectToAction("ChangePassword", "User", new { change = "error" });

            }
        }

        public ActionResult Join()
        {
            if (Session["user_login"] != null)
            {

                Models.Member ad = Session["user_login"] as Models.Member;
                return View(ad);
                //if (ad.IsMemberOfTeam == 0 || ad.IsMemberOfTeam == 1)
                //{
                //    return View(ad);
                //}
                //else
                //{
                //    return null;
                //}
            }
            else
            {
                return View();

            }
        }

        [HttpPost]
        public ActionResult JoinTeamProcess(FormCollection frm)
        {
            int ktUpdate = 0;
            int ktInsert = 0;
            if (Session["user_login"] != null)
            {
                try
                {
                    Models.Member ad = Session["user_login"] as Models.Member;
                    ad.IsMemberOfTeam = 0;
                    ktUpdate = MemberBusiness.EditMember(ad);
                }
                catch (Exception)
                {

                    ktUpdate = 0;
                }

            }
            else
            {

                try
                {

                    // TODO: Add insert logic here
                    Models.Member ad = new Models.Member()
                    {
                        UserName = frm["UserName"],
                        Password = frm["NewPassword"],
                        FullName = frm["FullName"],
                        Gender = frm["Gender"],
                        Phone = frm["Phone"],
                        Address = frm["Address"],
                        Email = frm["Email"],
                        IsMemberOfTeam = 0,
                        IsDeleted = 0,
                        Image = "Content/ImageUpload/Users/default.png"
                    };
                    // In error, need to be fixed!
                    ktInsert = MemberBusiness.AddMember(ad);

                }
                catch
                {
                    ktInsert = 0;
                }
            }
            if (ktUpdate > 0 || ktInsert > 0)
            {
                return RedirectToAction("Join", "User", new { change = "success" });
            }

            else
            {
                return RedirectToAction("Join", "User", new { change = "error" });
            }
        }
    }


}
