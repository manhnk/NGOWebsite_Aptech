using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;
using System.Data;

namespace BusinessLogicLayer
{
    public class AdminBusiness
    {
        private static List<Admin> AddAdminToList(DataTable dt)
        {
            List<Admin> ls = new List<Admin>();
            try
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Admin ad = new Admin()
                    {
                        Id = int.Parse(dt.Rows[i]["Id"].ToString()),
                        UserName = dt.Rows[i]["UserName"].ToString(),
                        Password = dt.Rows[i]["Password"].ToString(),
                        FullName = dt.Rows[i]["FullName"].ToString(),
                        Gender = dt.Rows[i]["Gender"].ToString(),
                        Phone = dt.Rows[i]["Phone"].ToString(),
                        Address = dt.Rows[i]["Address"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        IsActived = bool.Parse(dt.Rows[i]["IsActived"].ToString())

                    };

                    ls.Add(ad);

                }
            }
            catch (Exception)
            {
                return new List<Admin>();
            }
            return ls;
        }

        public static List<Admin> GetAllAdmin()
        {
            DataTable dt = DataAccessLayer.AdminDA.GetAllAdmin();
            return AddAdminToList(dt);
        }


        public static List<Admin> SearchAdmin(string value)
        {
                DataTable dt = DataAccessLayer.AdminDA.SearchAdmin(value);
                return AddAdminToList(dt);
        }

        public static List<Admin> GetAdminById(int id)
        {
                DataTable dt = DataAccessLayer.AdminDA.GetAdminById(id);
                return AddAdminToList(dt);
        }


        public static List<Admin> CheckUserExisted(string username,int ? id)
        {
                DataTable dt = DataAccessLayer.AdminDA.CheckUserExisted(username,id);
                return AddAdminToList(dt);
        }

        public static List<Admin> CheckLogin(string username,string password)
        {
            DataTable dt = DataAccessLayer.AdminDA.CheckLogin(username,password);
            return AddAdminToList(dt);
        }

        public static int AddAdmin(Admin ad)
        {
            int ins = 0;
            try
            {
                ins = DataAccessLayer.AdminDA.AddAdmin(ad);
            }
            catch (Exception)
            {
                return 0;
            }

            return ins;

        }

        public static int EditAdmin(Admin ad)
        {
            int upt = 0;
            try
            {
                upt = DataAccessLayer.AdminDA.EditAdmin(ad);
            }
            catch (Exception)
            {
                return 0;
            }
            return upt;
        }

        public static int DeleteAdmin(int id)
        {
            int del = 0;
            try
            {
                del = DataAccessLayer.AdminDA.DeleteAdmin(id);
            }
            catch (Exception)
            {
                return 0;
            }

            return del;
        }
    }
}
