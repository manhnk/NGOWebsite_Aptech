using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer;
using Models;

namespace BusinessLogicLayer
{
    public class CauseOfDonationBusiness
    {
        private static List<CauseOfDonation> AddCauseToList(DataTable dt)
        {
            List<CauseOfDonation> ls = new List<CauseOfDonation>();
            try
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CauseOfDonation ad = new CauseOfDonation()
                    {
                        Id = int.Parse(dt.Rows[i]["Id"].ToString()),
                        Description = dt.Rows[i]["Description"].ToString(),
                        IsFieldOfPrograms = int.Parse(dt.Rows[i]["IsFieldOfPrograms"].ToString()),
                        IsDeleted = int.Parse(dt.Rows[i]["IsDeleted"].ToString())
                    };

                    ls.Add(ad);

                }
            }
            catch (Exception)
            {
                return new List<CauseOfDonation>();
            }
            return ls;
        }

        public static List<CauseOfDonation> GetAllCauseOfDonation()
        {
            DataTable dt = DataAccessLayer.CauseOfDonationDA.GetAllCause();
            return AddCauseToList(dt);
        }


        public static List<CauseOfDonation> GetFieldOfPrograms()
        {
            DataTable dt = DataAccessLayer.CauseOfDonationDA.GetFieldOfPrograms();
            return AddCauseToList(dt);
        }
        public static List<CauseOfDonation> SearchCauseOfDonation(string value)
        {
            DataTable dt = DataAccessLayer.CauseOfDonationDA.SearchCause(value);
            return AddCauseToList(dt);
        }

        public static List<CauseOfDonation> GetCauseOfDonationById(int id)
        {
            DataTable dt = DataAccessLayer.CauseOfDonationDA.GetCauseById(id);
            return AddCauseToList(dt);
        }

        public static List<CauseOfDonation> CheckCauseExisted(string value,int ? id)
        {
            DataTable dt = DataAccessLayer.CauseOfDonationDA.CheckCauseExisted(value,id);
            return AddCauseToList(dt);
        }

        public static int AddCauseOfDonation(CauseOfDonation ad)
        {
            int ins = 0;
            try
            {
                ins = DataAccessLayer.CauseOfDonationDA.AddCause(ad);
            }
            catch (Exception)
            {
                return 0;
            }

            return ins;

        }

        public static int EditCauseOfDonation(CauseOfDonation ad)
        {
            int upt = 0;
            try
            {
                upt = DataAccessLayer.CauseOfDonationDA.EditCause(ad);
            }
            catch (Exception)
            {
                return 0;
            }
            return upt;
        }

        public static int DeleteCauseOfDonation(int id)
        {
            int del = 0;
            try
            {
                del = DataAccessLayer.CauseOfDonationDA.DeleteCause(id);
            }
            catch (Exception)
            {
                return 0;
            }

            return del;
        }

    }
}
