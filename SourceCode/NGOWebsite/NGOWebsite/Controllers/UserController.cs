using System;
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
            List<Models.Partners> ls = PartnersBusiness.GetAllPartners();
            return View(ls);
        }

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
                    Image = "Content/ImageUpload/Users/Hydrangeas.jpg"
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
                    return View(ls[0]);
                }
                else return null;
            }
            else return null;

        }

        //
        // POST: /Admin/Admin/Edit/5

        [HttpPost]
        public ActionResult EditProcess(FormCollection frm)
        {
            Models.Member mb = new Models.Member();
            mb = (Member)Session["user_login"];
            int kt = 0;
            try
            {
                
                // TODO: Add insert logic here
                Models.Member ad = new Models.Member()
                {
                    Id = mb.Id,
                    UserName = frm["UserName"],
                    Password = frm["Password"],
                    FullName = frm["FullName"],
                    Gender = frm["Gender"],
                    Phone = frm["Phone"],
                    Address = frm["Address"],
                    Email = frm["Email"],
                    IsMemberOfTeam = 0,
                    IsDeleted = 0,
                    Image = frm["Image"]
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
                        Image = frm["Image"]
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
