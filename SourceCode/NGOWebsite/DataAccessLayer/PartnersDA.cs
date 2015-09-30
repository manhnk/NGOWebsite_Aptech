using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models;

namespace DataAccessLayer
{
    public class PartnersDA
    {
        public static DataTable GetAllPartners()
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_getAllPartners";
                dt = DataConnect.GetAllData(sql);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }


        public static int AddPartner(Models.Partners partner)
        {
            int kt = 0;
            try
            {
                string sql = "sp_addNewPartner";
                List<string> param = new List<string>();
                param.Add("@name");
                param.Add("@address");
                param.Add("@email");
                param.Add("@phone");
                param.Add("@logo");
                param.Add("@profile");
                param.Add("@isDeleted");

                List<object> value = new List<object>();
                value.Add(partner.Name);
                value.Add(partner.Address);
                value.Add(partner.Email);
                value.Add(partner.Phone);
                value.Add(partner.Logo);
                value.Add(partner.Profile);
                value.Add(partner.IsDeleted);

                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static int EditPartner(Models.Partners partner)
        {
            int kt = 0;
            try
            {
                string sql = "sp_editPartner";
                List<string> param = new List<string>();
                param.Add("@id");
                param.Add("@name");
                param.Add("@address");
                param.Add("@email");
                param.Add("@phone");
                param.Add("@logo");
                param.Add("@profile");
                param.Add("@isDeleted");

                List<object> value = new List<object>();
                value.Add(partner.Id);
                value.Add(partner.Name);
                value.Add(partner.Address);
                value.Add(partner.Email);
                value.Add(partner.Phone);
                value.Add(partner.Logo);
                value.Add(partner.Profile);
                value.Add(partner.IsDeleted);

                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static int DeletePartner(int id)
        {
            int kt = 0;
            try
            {
                string sql = "sp_deletePartner";
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

        public static DataTable SearchPartner(string text)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_searchPartners";
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

        public static DataTable GetPartnerById(int id)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_findPartnerById";
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

        public static DataTable CheckPartnerExisted(string text,int ? id)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_checkPartnerExisted";
                List<string> param = new List<string>();
                param.Add("@value");
                param.Add("@id");

                List<object> value = new List<object>();
                value.Add(text);
                value.Add(id);
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
