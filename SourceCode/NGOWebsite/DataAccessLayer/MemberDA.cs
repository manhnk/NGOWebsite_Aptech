using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer
{
    public class MemberDA
    {
        public static DataTable GetAllMember()
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_getAllMember";
                dt = DataConnect.GetAllData(sql);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }

        public static int AddMember(Models.Member mem)
        {
            int kt = 0;
            try
            {
                string sql = "sp_addNewMember";
                List<string> param = new List<string>();
                param.Add("@username");
                param.Add("@password");
                param.Add("@fullname");
                param.Add("@gender");
                param.Add("@address");
                param.Add("@phone");
                param.Add("@email");
                param.Add("@isMemberOfTeam");
                param.Add("@isDeleted");
                param.Add("@image");

                List<object> value = new List<object>();
                value.Add(mem.UserName);
                value.Add(DataConnect.GetMd5Hash(mem.Password));
                value.Add(mem.FullName);
                value.Add(mem.Gender);
                value.Add(mem.Address);
                value.Add(mem.Phone);
                value.Add(mem.Email);
                value.Add(mem.IsMemberOfTeam);
                value.Add(mem.IsDeleted);
                value.Add(mem.Image);

                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static int EditMember(Models.Member mem)
        {
            int kt = 0;
            try
            {
                string sql = "sp_editMember";
                List<string> param = new List<string>();
                param.Add("@id");
                param.Add("@username");
                param.Add("@password");
                param.Add("@fullname");
                param.Add("@gender");
                param.Add("@address");
                param.Add("@phone");
                param.Add("@email");
                param.Add("@isMemberOfTeam");
                param.Add("@isDeleted");
                param.Add("@image");


                List<object> value = new List<object>();
                value.Add(mem.Id);
                value.Add(mem.UserName);
                value.Add(DataConnect.GetMd5Hash(mem.Password));
                value.Add(mem.FullName);
                value.Add(mem.Gender);
                value.Add(mem.Address);
                value.Add(mem.Phone);
                value.Add(mem.Email);
                value.Add(mem.IsMemberOfTeam);
                value.Add(mem.IsDeleted);
                value.Add(mem.Image);

                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static int DeleteMember(int id)
        {
            int kt = 0;
            try
            {
                string sql = "sp_deleteMember";
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

        public static DataTable SearchMember(string text)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_searchMember";
                List<string> param = new List<string>();
                param.Add("@value");

                List<object> value = new List<object>();
                value.Add(text);
                dt = DataConnect.FindData(sql, param, value);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }

        public static DataTable GetMemberById(int id)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_findMemberById";
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
                string sql = "sp_checkUserMemberExisted";
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

        public static DataTable CheckLogin(string username, string password)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_checkLoginMember";
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
