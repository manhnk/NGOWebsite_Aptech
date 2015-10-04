using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;

namespace DataAccessLayer
{
    public class DonationDA
    {
        public static DataTable GetAllDonation()
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_getAllDonation";
                dt = DataConnect.GetAllData(sql);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }



        public static int AddDonation(Models.Donation donation)
        {
            int kt = 0;
            try
            {
                string sql = "sp_addNewDonation";
                List<string> param = new List<string>();
                param.Add("@fullname");
                param.Add("@gender");
                param.Add("@email");
                param.Add("@causeId");
                param.Add("@programId");
                param.Add("@dateOfDonation");
                param.Add("@amount");
                param.Add("@creditType");
                param.Add("@cardNumber");
                param.Add("@isDeleted");

                List<object> value = new List<object>();
                value.Add(donation.FullNameDonator);
                value.Add(donation.GenderDonator);
                value.Add(donation.EmailDonator);
                value.Add(donation.CauseId);
                value.Add(donation.ProgramId);
                value.Add(donation.DateOfDonation);
                value.Add(donation.Amount);
                value.Add(donation.CreditType);
                value.Add(donation.CardNumber);
                value.Add(donation.IsDeleted);


                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static int EditDonation(Models.Donation donation)
        {
            int kt = 0;
            try
            {
                string sql = "sp_editDonation";
                List<string> param = new List<string>();
                param.Add("@id");
                param.Add("@fullname");
                param.Add("@gender");
                param.Add("@email");
                param.Add("@causeId");
                param.Add("@programId");
                param.Add("@dateOfDonation");
                param.Add("@amount");
                param.Add("@creditType");
                param.Add("@cardNumber");
                param.Add("@isDeleted");

                List<object> value = new List<object>();
                value.Add(donation.Id);
                value.Add(donation.FullNameDonator);
                value.Add(donation.GenderDonator);
                value.Add(donation.EmailDonator);
                value.Add(donation.CauseId);
                value.Add(donation.ProgramId);
                value.Add(donation.DateOfDonation);
                value.Add(donation.Amount);
                value.Add(donation.CreditType);
                value.Add(donation.CardNumber);
                value.Add(donation.IsDeleted);

                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static int DeleteDonation(int id)
        {
            int kt = 0;
            try
            {
                string sql = "sp_deleteDonation";
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

        public static DataTable SearchDonation(string text, string flag, int id)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_searchDonation";
                List<string> param = new List<string>();
                param.Add("@value");
                param.Add("@flag");
                param.Add("@id");

                List<object> value = new List<object>();
                value.Add(text);
                value.Add(flag);
                value.Add(id);
                dt = DataConnect.FindData(sql, param, value);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }

        public static DataTable GetDonationByProgramOrCause(string flag)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_getDonationByProgramOrCause";
                List<string> param = new List<string>();
                param.Add("@flag");

                List<object> value = new List<object>();
                value.Add(flag);
                dt = DataConnect.FindData(sql, param, value);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }

        public static DataTable GetDonation(int id, string flag)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_getDonation";
                List<string> param = new List<string>();
                param.Add("@id");
                param.Add("@flag");

                List<object> value = new List<object>();
                value.Add(id);
                value.Add(flag);
                dt = DataConnect.FindData(sql, param, value);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }

        public static DataTable GetDonationById(int id)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_findDonationById";
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
