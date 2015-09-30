using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models;

namespace DataAccessLayer
{
    public class ProgramsDA
    {
        public static DataTable GetAllPrograms()
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_getAllPrograms";
                dt = DataConnect.GetAllData(sql);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }



        public static int AddProgram(Models.Programs pro)
        {
            int kt = 0;
            try
            {
                string sql = "sp_addNewProgram";
                List<string> param = new List<string>();
                param.Add("@name");
                param.Add("@content");
                param.Add("@status");
                param.Add("@causeId");
                param.Add("@isDeleted");

                List<object> value = new List<object>();
                value.Add(pro.Name);
                value.Add(pro.Contents);
                value.Add(pro.Status);
                value.Add(pro.CauseId);
                value.Add(pro.IsDeleted);


                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static int EditProgram(Models.Programs pro)
        {
            int kt = 0;
            try
            {
                string sql = "sp_editProgram";
                List<string> param = new List<string>();
                param.Add("@id");
                param.Add("@name");
                param.Add("@content");
                param.Add("@status");
                param.Add("@causeId");
                param.Add("@isDeleted");

                List<object> value = new List<object>();
                value.Add(pro.Id);
                value.Add(pro.Name);
                value.Add(pro.Contents);
                value.Add(pro.Status);
                value.Add(pro.CauseId);
                value.Add(pro.IsDeleted);

                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static int DeleteProgram(int id)
        {
            int kt = 0;
            try
            {
                string sql = "sp_deleteProgram";
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

        public static DataTable SearchProgram(string text)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_searchPrograms";
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

        public static DataTable GetProgramById(int id)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_findProgramById";
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

     
    }
}
