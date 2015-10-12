using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLogicLayer;

namespace NGOWebsite.Areas.Admin.Controllers
{
    public class MemberController : Controller
    {

        public ActionResult Details(int id)
        {
            List<Member> ls = MemberBusiness.GetMemberById(id);
            if (ls.Count > 0)
            {
                return View(ls[0]);
            }
            return View();
        }

        //
        // GET: /Admin/Member/Create


        public ActionResult ListMember()
        {
            List<Member> ls = MemberBusiness.GetAllMember();
            if (ls.Count > 0)
            {
                return View(ls);
            }
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }

        public ActionResult ProcessJoin(int id, string flag)
        {
            int kt = 0;
            try
            {
                Member m = MemberBusiness.GetMemberById(id)[0];
                if (flag == "jointeam")
                {
                    m.IsMemberOfTeam = 1;
                }
                else
                {
                    m.IsMemberOfTeam = -1;
                }
                kt = MemberBusiness.EditMember(m);
            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("ListMember", "Member", new { update = "success" });
            }
            else
            {
                return RedirectToAction("ListMember", "Member", new { update = "error" });
            }
        }

        public ActionResult ResetPassword(int id)
        {
            int kt = 0;
            try
            {

                kt = MemberBusiness.ChangePassword(id, "1234567");
            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("ListMember", "Member", new { resetpass = "success" });
            }
            else
            {
                return RedirectToAction("ListMember", "Member", new { resetpass = "error" });
            }
        }

        //
        // POST: /Admin/Member/Create

        [HttpPost]
        public ActionResult CreateProcess(FormCollection frm)
        {
            int kt = 0;
            try
            {
                int join = -1;
                if (frm["cbIsMemberOfTeam"].ToString().Contains("rmb"))
                {
                    join = 1;
                }
                // TODO: Add insert logic here
                Models.Member ad = new Models.Member()
                {
                    UserName = frm["UserName"],
                    Password = "1234567",
                    FullName = frm["FullName"],
                    Gender = frm["Gender"],
                    Phone = frm["Phone"],
                    Address = frm["Address"],
                    Email = frm["Email"],
                    IsMemberOfTeam = join,
                    Image = "Content/ImageUpload/Users/default.png",
                    IsDeleted = 0
                };

                kt = MemberBusiness.AddMember(ad);

            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("ListMember", "Member", new { add = "success" });
            }
            else
            {
                return RedirectToAction("ListMember", "Member", new { add = "error" });
            }
        }


        public ActionResult Delete(int id)
        {
            int kt = 0;
            try
            {
                kt = MemberBusiness.DeleteMember(id);
            }
            catch
            {
                kt = 0;
            }

            if (kt > 0)
            {
                return RedirectToAction("ListMember", "Member", new { delete = "success" });
            }
            else
            {
                return RedirectToAction("ListMember", "Member", new { delete = "error" });
            }
        }



    }
}
