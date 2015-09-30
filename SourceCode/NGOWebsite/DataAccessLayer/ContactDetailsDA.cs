using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer
{
   public class ContactDetailsDA
    {
        public static DataTable GetAllContact()
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_getAllContact";
                dt = DataConnect.GetAllData(sql);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }


        public static int AddContact(Models.ContactDetails contact)
        {
            int kt = 0;
            try
            {
                string sql = "sp_addNewContact";
                List<string> param = new List<string>();
                param.Add("@address");
                param.Add("@phone");
                param.Add("@email");

                List<object> value = new List<object>();
                value.Add(contact.Address);
                value.Add(contact.Phone);
                value.Add(contact.Email);


                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static int EditContact(Models.ContactDetails contact)
        {
            int kt = 0;
            try
            {
                string sql = "sp_editContact";
                List<string> param = new List<string>();
                param.Add("@id");
                param.Add("@address");
                param.Add("@phone");
                param.Add("@email");

                List<object> value = new List<object>();
                value.Add(contact.Id);
                value.Add(contact.Address);
                value.Add(contact.Phone);
                value.Add(contact.Email);

                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static int DeleteContact(int id)
        {
            int kt = 0;
            try
            {
                string sql = "sp_deleteContact";
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

        public static DataTable SearchContact(string text)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_searchContact";
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

        public static DataTable GetContactById(int id)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_findContactById";
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
