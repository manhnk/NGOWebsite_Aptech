using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer
{
   public class CauseOfDonationDA
    {
        public static DataTable GetAllCause()
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_getAllCause";
                dt = DataConnect.GetAllData(sql);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }

        public static DataTable GetFieldOfPrograms()
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_getFieldOfProgram";
                dt = DataConnect.GetAllData(sql);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }


        public static int AddCause(Models.CauseOfDonation cause)
        {
            int kt = 0;
            try
            {
                string sql = "sp_addNewCause";
                List<string> param = new List<string>();
                param.Add("@description");
                param.Add("@isFieldOfProgram");
                param.Add("@IsDeleted");

                List<object> value = new List<object>();
                value.Add(cause.Description);
                value.Add(cause.IsFieldOfPrograms);
                value.Add(cause.IsDeleted);


                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static int EditCause(Models.CauseOfDonation cause)
        {
            int kt = 0;
            try
            {
                string sql = "sp_editCause";
                List<string> param = new List<string>();
                param.Add("@id");
                param.Add("@description");
                param.Add("@isFieldOfProgram");
                param.Add("@IsDeleted");

                List<object> value = new List<object>();
                value.Add(cause.Id);
                value.Add(cause.Description);
                value.Add(cause.IsFieldOfPrograms);
                value.Add(cause.IsDeleted);

                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static int DeleteCause(int id)
        {
            int kt = 0;
            try
            {
                string sql = "sp_deleteCause";
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

        public static DataTable SearchCause(string text)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_searchCause";
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

        public static DataTable GetCauseById(int id)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_findCauseById";
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

        public static DataTable CheckCauseExisted(string cause,int ? id)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_checkCauseExisted";
                List<string> param = new List<string>();
                param.Add("@description");
                param.Add("@id");

                List<object> value = new List<object>();
                value.Add(cause);
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
