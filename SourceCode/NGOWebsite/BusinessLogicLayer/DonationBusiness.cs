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
    public class DonationBusiness
    {
        private static List<Donation> AddDonationToList(DataTable dt)
        {
            List<Donation> ls = new List<Donation>();
            try
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string program = "";
                    Nullable<int> programId= null;
                    if ((dt.Rows[i]["ProgramId"].ToString()) != "")
                    {
                        programId = int.Parse(dt.Rows[i]["ProgramId"].ToString());
                        program = dt.Rows[i]["Name"].ToString();
                    }

                    Nullable<int> causeId = null;
                    string causeOfDonation = "";
                    if ((dt.Rows[i]["CauseId"].ToString()) != "")
                    {
                        causeId = int.Parse(dt.Rows[i]["CauseID"].ToString());
                        causeOfDonation = dt.Rows[i]["Description"].ToString();
                    }

                    Donation ad = new Donation()
                    {
                        Id = int.Parse(dt.Rows[i]["Id"].ToString()),
                        FullNameDonator = dt.Rows[i]["FullNameDonator"].ToString(),
                        EmailDonator = dt.Rows[i]["EmailDonator"].ToString(),
                        GenderDonator = dt.Rows[i]["GenderDonator"].ToString(),
                        CauseId= causeId,
                        CauseOfDonation = causeOfDonation,
                        ProgramId = programId,
                        Program = program,
                        DateOfDonation = DateTime.Parse(dt.Rows[i]["DateOfDonation"].ToString()),
                        Amount = double.Parse(dt.Rows[i]["Amount"].ToString()),
                        CreditType = dt.Rows[i]["CreditType"].ToString(),
                        CardNumber = dt.Rows[i]["CardNumber"].ToString(),
                        IsDeleted = int.Parse(dt.Rows[i]["IsDeleted"].ToString())
                    };

                    ls.Add(ad);

                }
            }
            catch (Exception)
            {
                return new List<Donation>();
            }
            return ls;
        }

        private static List<Donation> AddDonationToList2(DataTable dt,string flag)
        {
            List<Donation> ls = new List<Donation>();
            try
            {
                if (flag == "program")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Donation ad = new Donation()
                        {
                            Program = dt.Rows[i]["Name"].ToString(),
                            ProgramId = int.Parse(dt.Rows[i]["Id"].ToString()),
                            TotalAmount = double.Parse(dt.Rows[i]["TotalAmount"].ToString()),
                            NumberOfDonation = int.Parse(dt.Rows[i]["NumberOfDonation"].ToString())
                        };

                        ls.Add(ad);

                    }
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Donation ad = new Donation()
                        {
                            CauseOfDonation = dt.Rows[i]["Description"].ToString(),
                            CauseId = int.Parse(dt.Rows[i]["Id"].ToString()),
                            TotalAmount = double.Parse(dt.Rows[i]["TotalAmount"].ToString()),
                            NumberOfDonation = int.Parse(dt.Rows[i]["NumberOfDonation"].ToString())
                        };

                        ls.Add(ad);

                    }
                }
               
            }
            catch (Exception)
            {
                return new List<Donation>();
            }
            return ls;
        }

        public static List<Donation> GetAllDonation()
        {
            DataTable dt = DataAccessLayer.DonationDA.GetAllDonation();
            return AddDonationToList(dt);
        }

        public static List<Donation> SearchDonation(string value,string flag,int id)
        {
            DataTable dt = DataAccessLayer.DonationDA.SearchDonation(value,flag,id);
            return AddDonationToList(dt);
        }

        public static List<Donation> GetDonation(string flag, int id)
        {
            DataTable dt = DataAccessLayer.DonationDA.GetDonation(id,flag);
            return AddDonationToList(dt);
        }

        public static List<Donation> GetDonationByProgramOrCause(string flag)
        {
            DataTable dt = DataAccessLayer.DonationDA.GetDonationByProgramOrCause(flag);
            return AddDonationToList2(dt,flag);
        }

        public static List<Donation> GetDonationById(int id)
        {
            DataTable dt = DataAccessLayer.DonationDA.GetDonationById(id);
            return AddDonationToList(dt);
        }

        public static int AddDonation(Donation ad)
        {
            int ins = 0;
            try
            {
                ins = DataAccessLayer.DonationDA.AddDonation(ad);
            }
            catch (Exception)
            {
                return 0;
            }

            return ins;

        }

        public static int EditDonation(Donation ad)
        {
            int upt = 0;
            try
            {
                upt = DataAccessLayer.DonationDA.EditDonation(ad);
            }
            catch (Exception)
            {
                return 0;
            }
            return upt;
        }

        public static int DeleteDonation(int id)
        {
            int del = 0;
            try
            {
                del = DataAccessLayer.DonationDA.DeleteDonation(id);
            }
            catch (Exception)
            {
                return 0;
            }

            return del;
        }
    }
}
