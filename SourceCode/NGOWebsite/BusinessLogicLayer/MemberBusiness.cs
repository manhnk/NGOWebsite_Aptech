using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayer
{
    public class MemberBusiness
    {
        private static List<Member> AddMemberToList(DataTable dt)
        {
            List<Member> ls = new List<Member>();
            try
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Member ad = new Member()
                    {
                        Id = int.Parse(dt.Rows[i]["Id"].ToString()),
                        UserName = dt.Rows[i]["UserName"].ToString(),
                        Password = dt.Rows[i]["Password"].ToString(),
                        FullName = dt.Rows[i]["FullName"].ToString(),
                        Gender = dt.Rows[i]["Gender"].ToString(),
                        Phone = dt.Rows[i]["Phone"].ToString(),
                        Address = dt.Rows[i]["Address"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        IsMemberOfTeam = int.Parse(dt.Rows[i]["IsMemberOfTeam"].ToString()),
                        IsDeleted = int.Parse(dt.Rows[i]["IsDeleted"].ToString()),
                        Image = dt.Rows[i]["IsActived"].ToString()

                    };

                    ls.Add(ad);

                }
            }
            catch (Exception)
            {
                return new List<Member>();
            }
            return ls;
        }

        public static List<Member> GetAllMember()
        {
            DataTable dt = DataAccessLayer.MemberDA.GetAllMember();
            return AddMemberToList(dt);
        }


        public static List<Member> SearchMember(string value)
        {
            DataTable dt = DataAccessLayer.MemberDA.SearchMember(value);
            return AddMemberToList(dt);
        }

        public static List<Member> GetMemberById(int id)
        {
            DataTable dt = DataAccessLayer.MemberDA.GetMemberById(id);
            return AddMemberToList(dt);
        }


        public static List<Member> CheckUserExisted(string username,int ? id)
        {
            DataTable dt = DataAccessLayer.MemberDA.CheckUserExisted(username,id);
            return AddMemberToList(dt);
        }

        public static List<Member> CheckLogin(string username, string password)
        {
            DataTable dt = DataAccessLayer.MemberDA.CheckLogin(username, password);
            return AddMemberToList(dt);
        }

        public static int AddMember(Member ad)
        {
            int ins = 0;
            try
            {
                ins = DataAccessLayer.MemberDA.AddMember(ad);
            }
            catch (Exception)
            {
                return 0;
            }

            return ins;

        }

        public static int EditMember(Member ad)
        {
            int upt = 0;
            try
            {
                upt = DataAccessLayer.MemberDA.EditMember(ad);
            }
            catch (Exception)
            {
                return 0;
            }
            return upt;

        }

        public static int ChangePassword(int id,string pass)
        {
            int upt = 0;
            try
            {
                upt = DataAccessLayer.MemberDA.ChangePassword(id,pass);
            }
            catch (Exception)
            {
                return 0;
            }
            return upt;
        }
        public static int DeleteMember(int id)
        {
            int del = 0;
            try
            {
                del = DataAccessLayer.MemberDA.DeleteMember(id);
            }
            catch (Exception)
            {
                return 0;
            }

            return del;
        }
    }
}
