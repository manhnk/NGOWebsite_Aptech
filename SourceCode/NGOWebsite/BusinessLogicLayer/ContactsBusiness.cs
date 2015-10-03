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
    public class ContactsBusiness
    {
        private static List<ContactDetails> AddContactToList(DataTable dt)
        {
            List<ContactDetails> ls = new List<ContactDetails>();
            try
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ContactDetails ad = new ContactDetails()
                    {
                        Id = int.Parse(dt.Rows[i]["Id"].ToString()),
                        Phone = dt.Rows[i]["Phone"].ToString(),
                        Email= dt.Rows[i]["Email"].ToString(),
                        Address= dt.Rows[i]["Address"].ToString()
                    };

                    ls.Add(ad);

                }
            }
            catch (Exception)
            {
                return new List<ContactDetails>();
            }
            return ls;
        }

        public static List<ContactDetails> GetAllContactDetails()
        {
            DataTable dt = DataAccessLayer.ContactDetailsDA.GetAllContact();
            return AddContactToList(dt);
        }

        public static List<ContactDetails> SearchContactDetails(string value)
        {
            DataTable dt = DataAccessLayer.ContactDetailsDA.SearchContact(value);
            return AddContactToList(dt);
        }

        public static List<ContactDetails> GetContactDetailsById(int id)
        {
            DataTable dt = DataAccessLayer.ContactDetailsDA.GetContactById(id);
            return AddContactToList(dt);
        }


        public static int AddContactDetails(ContactDetails ad)
        {
            int ins = 0;
            try
            {
                ins = DataAccessLayer.ContactDetailsDA.AddContact(ad);
            }
            catch (Exception)
            {
                return 0;
            }

            return ins;

        }

        public static int EditContactDetails(ContactDetails ad)
        {
            int upt = 0;
            try
            {
                upt = DataAccessLayer.ContactDetailsDA.EditContact(ad);
            }
            catch (Exception)
            {
                return 0;
            }
            return upt;
        }

        public static int DeleteContactDetails(int id)
        {
            int del = 0;
            try
            {
                del = DataAccessLayer.ContactDetailsDA.DeleteContact(id);
            }
            catch (Exception)
            {
                return 0;
            }

            return del;
        }

    }
}
