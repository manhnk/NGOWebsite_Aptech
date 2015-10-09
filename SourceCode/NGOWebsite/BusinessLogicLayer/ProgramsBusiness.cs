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
   public class ProgramsBusiness
    {
        private static List<Programs> AddProgramsToList(DataTable dt)
        {
            List<Programs> ls = new List<Programs>();
            try
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Programs ad = new Programs()
                    {
                        Id = int.Parse(dt.Rows[i]["Id"].ToString()),
                        Name = dt.Rows[i]["Name"].ToString(),
                        Contents = dt.Rows[i]["Contents"].ToString(),
                        Cause = dt.Rows[i]["Description"].ToString(),
                        Status = int.Parse(dt.Rows[i]["Status"].ToString()),
                        CauseId = int.Parse(dt.Rows[i]["CauseId"].ToString()),
                        IsDeleted = int.Parse(dt.Rows[i]["IsDeleted"].ToString())
                    };

                    ls.Add(ad);

                }
            }
            catch (Exception)
            {
                return new List<Programs>();
            }
            return ls;
        }

        public static List<Programs> GetAllPrograms()
        {
            DataTable dt = DataAccessLayer.ProgramsDA.GetAllPrograms();
            return AddProgramsToList(dt);
        }

        public static List<Programs> SearchPrograms(string value)
        {
            DataTable dt = DataAccessLayer.ProgramsDA.SearchProgram(value);
            return AddProgramsToList(dt);
        }

        public static List<Programs> GetProgramsById(int id)
        {
            DataTable dt = DataAccessLayer.ProgramsDA.GetProgramById(id);
            return AddProgramsToList(dt);
        }

        public static int CheckNameExisted(string text, int? id)
        {
            DataTable dt = DataAccessLayer.ProgramsDA.CheckNameExisted(text, id);
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            return 0;
        }

        public static int AddPrograms(Programs ad)
        {
            int ins = 0;
            try
            {
                ins = DataAccessLayer.ProgramsDA.AddProgram(ad);
            }
            catch (Exception)
            {
                return 0;
            }

            return ins;

        }

        public static int EditPrograms(Programs ad)
        {
            int upt = 0;
            try
            {
                upt = DataAccessLayer.ProgramsDA.EditProgram(ad);
            }
            catch (Exception)
            {
                return 0;
            }
            return upt;
        }

        public static int DeletePrograms(int id)
        {
            int del = 0;
            try
            {
                del = DataAccessLayer.ProgramsDA.DeleteProgram(id);
            }
            catch (Exception)
            {
                return 0;
            }

            return del;
        }
    }
}
