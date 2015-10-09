using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class PartnersBusiness
    {
        private static List<Partners> AddPartnerToList(DataTable dt)
        {
            List<Partners> ls = new List<Partners>();
            try
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Partners ad = new Partners()
                    {
                        Id = int.Parse(dt.Rows[i]["Id"].ToString()),
                        Name = dt.Rows[i]["Name"].ToString(),
                        Address = dt.Rows[i]["Address"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        Phone = dt.Rows[i]["Phone"].ToString(),
                        Logo = dt.Rows[i]["Logo"].ToString(),
                        Profile = dt.Rows[i]["Profile"].ToString(),
                        IsDeleted = int.Parse(dt.Rows[i]["IsDeleted"].ToString())
                    };

                    ls.Add(ad);

                }
            }
            catch (Exception)
            {
                return new List<Partners>();
            }
            return ls;
        }

        public static List<Partners> GetAllPartners()
        {
            DataTable dt = DataAccessLayer.PartnersDA.GetAllPartners();
            return AddPartnerToList(dt);
        }

        public static List<Partners> SearchPartners(string value)
        {
            DataTable dt = DataAccessLayer.PartnersDA.SearchPartner(value);
            return AddPartnerToList(dt);
        }

        public static List<Partners> GetPartnersById(int id)
        {
            DataTable dt = DataAccessLayer.PartnersDA.GetPartnerById(id);
            return AddPartnerToList(dt);
        }

        public static List<Partners> CheckPartnerExisted(string value,int ? id)
        {
            DataTable dt = DataAccessLayer.PartnersDA.CheckPartnerExisted(value,id);
            return AddPartnerToList(dt);
        }

        public static int AddPartners(Partners ad)
        {
            int ins = 0;
            try
            {
                ins = DataAccessLayer.PartnersDA.AddPartner(ad);
            }
            catch (Exception)
            {
                return 0;
            }

            return ins;

        }

        public static int EditPartners(Partners ad)
        {
            int upt = 0;
            try
            {
                upt = DataAccessLayer.PartnersDA.EditPartner(ad);
            }
            catch (Exception)
            {
                return 0;
            }
            return upt;
        }

        public static int DeletePartners(int id)
        {
            int del = 0;
            try
            {
                del = DataAccessLayer.PartnersDA.DeletePartner(id);
            }
            catch (Exception)
            {
                return 0;
            }

            return del;
        }
    }
}
