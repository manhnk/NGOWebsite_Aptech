using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class InformationsBusiness
    {
        private static List<Informations> AddInformationToList(DataTable dt)
        {
            List<Informations> ls = new List<Informations>();
            try
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Informations ad = new Informations()
                    {
                        Id = int.Parse(dt.Rows[i]["Id"].ToString()),
                        Subject = dt.Rows[i]["Subject"].ToString(),
                        TextTooltip = dt.Rows[i]["TextTooltip"].ToString(),
                        Contents = dt.Rows[i]["Content"].ToString(),
                        ParentId = int.Parse(dt.Rows[i]["ParentId"].ToString()),
                        ParentName = dt.Rows[i]["Description"].ToString(),
                        Position = int.Parse(dt.Rows[i]["Position"].ToString()),
                        IsDeleted = int.Parse(dt.Rows[i]["IsDeleted"].ToString())
                    };

                    ls.Add(ad);

                }
            }
            catch (Exception)
            {
                return new List<Informations>();
            }
            return ls;
        }

        public static List<Informations> GetAllInformations()
        {
            DataTable dt = DataAccessLayer.InformationsDA.GetAllInfor();
            return AddInformationToList(dt);
        }

        public static List<Informations> SearchInformations(string value)
        {
            DataTable dt = DataAccessLayer.InformationsDA.SearchInfor(value);
            return AddInformationToList(dt);
        }

        public static List<Informations> GetInformationsById(int id)
        {
            DataTable dt = DataAccessLayer.InformationsDA.GetInforById(id);
            return AddInformationToList(dt);
        }

        public static List<Informations> CheckInformationExisted(string value,int ? id)
        {
            DataTable dt = DataAccessLayer.InformationsDA.CheckInforExisted(value,id);
            return AddInformationToList(dt);
        }

        public int AddInformations(Informations ad)
        {
            int ins = 0;
            try
            {
                ins = DataAccessLayer.InformationsDA.AddInfor(ad);
            }
            catch (Exception)
            {
                return 0;
            }

            return ins;

        }

        public int EditInformations(Informations ad)
        {
            int upt = 0;
            try
            {
                upt = DataAccessLayer.InformationsDA.EditInfor(ad);
            }
            catch (Exception)
            {
                return 0;
            }
            return upt;
        }

        public int DeleteInformations(int id)
        {
            int del = 0;
            try
            {
                del = DataAccessLayer.InformationsDA.DeleteInfor(id);
            }
            catch (Exception)
            {
                return 0;
            }

            return del;
        }
    }
}
