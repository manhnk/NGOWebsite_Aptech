using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models;


namespace DataAccessLayer
{
    public class AdminDA
    {
        public static DataTable GetAllAdmin()
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_getAllAdmin";
                dt=DataConnect.GetAllData(sql);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }

        public static int AddAdmin(Models.Admin admin)
        {
            int kt=0;
            try
            {
                string sql = "sp_AddNewAdmin";
                List<string> param = new List<string>();
                param.Add("@username");
                param.Add("@password");
                param.Add("@fullname");
                param.Add("@gender");
                param.Add("@phone");
                param.Add("@address");
                param.Add("@email");
                param.Add("@isActived");
                param.Add("@isSuperAdmin");

                List<object> value = new List<object>();
                value.Add(admin.UserName);
                value.Add(DataConnect.GetMd5Hash(admin.Password));                
                value.Add(admin.FullName);
                value.Add(admin.Gender);
                value.Add(admin.Phone);
                value.Add(admin.Address);
                value.Add(admin.Email);
                value.Add(admin.IsActived);
                value.Add(admin.IsSuperAdmin);

                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;   
            }
            return kt;
        }

        public static int EditAdmin(Models.Admin admin)
        {
            int kt = 0;
            try
            {
                string sql = "sp_editAdmin";
                List<string> param = new List<string>();
                param.Add("@id");
                param.Add("@password");
                param.Add("@fullname");
                param.Add("@gender");
                param.Add("@phone");
                param.Add("@address");
                param.Add("@email");
                param.Add("@isActived");

                List<object> value = new List<object>();
                value.Add(admin.Id);
                value.Add(DataConnect.GetMd5Hash(admin.Password));
                value.Add(admin.FullName);
                value.Add(admin.Gender);
                value.Add(admin.Phone);
                value.Add(admin.Address);
                value.Add(admin.Email);
                value.Add(admin.IsActived);

                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static int DeleteAdmin(int id)
        {
            int kt = 0;
            try
            {
                string sql = "sp_deleteAdmin";
                List<string> param = new List<string>();
                param.Add("@id");

                List<object> value = new List<object>();
                value.Add(id);
               
                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static DataTable SearchAdmin(string text)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_searchAdmin";
                 List<string> param = new List<string>();
                param.Add("@value");

                List<object> value = new List<object>();
                value.Add(text);
                dt = DataConnect.FindData(sql,param,value);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }

        public static DataTable GetAdminById(int id)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_findAdminById";
                List<string> param = new List<string>();
                param.Add("@id");

                List<object> value = new List<object>();
                value.Add(id);
                dt = DataConnect.FindData(sql, param, value);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }

        public static DataTable CheckUserExisted(string username,int ? id)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_checkUserNameExisted";
                List<string> param = new List<string>();
                param.Add("@username");
                param.Add("@id");

                List<object> value = new List<object>();
                value.Add(username);
                value.Add(id);
                dt = DataConnect.FindData(sql, param, value);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }

        public static DataTable CheckLogin(string username,string password)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_checkLogin";
                List<string> param = new List<string>();
                param.Add("@username");
                param.Add("@password");

                List<object> value = new List<object>();
                value.Add(username);
                value.Add(DataConnect.GetMd5Hash(password));
                dt = DataConnect.FindData(sql, param, value);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }
    }
}
