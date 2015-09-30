using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models;

namespace DataAccessLayer
{
    public class MessageDA
    {
        public static DataTable GetAllMessage()
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_getAllMessage";
                dt = DataConnect.GetAllData(sql);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }

        public static int AddMessage(Models.Message mes)
        {
            int kt = 0;
            try
            {
                string sql = "sp_addNewMessage";
                List<string> param = new List<string>();
                param.Add("@programId");
                param.Add("@name");
                param.Add("@email");
                param.Add("@message");
                param.Add("@status");
                param.Add("@replier");
                param.Add("@isDeleted");

                List<object> value = new List<object>();
                value.Add(mes.ProgramId);
                value.Add(mes.SenderName);
                value.Add(mes.SenderEmail);
                value.Add(mes.Messages);
                value.Add(mes.Status);
                value.Add(mes.ReplierId);
                value.Add(mes.IsDeleted);

                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static int EditMessage(Models.Message mes)
        {
            int kt = 0;
            try
            {
                string sql = "sp_editMessage";
                List<string> param = new List<string>();
                param.Add("@id");
                param.Add("@programId");
                param.Add("@name");
                param.Add("@email");
                param.Add("@message");
                param.Add("@status");
                param.Add("@replier");
                param.Add("@isDeleted");

                List<object> value = new List<object>();
                value.Add(mes.Id);
                value.Add(mes.ProgramId);
                value.Add(mes.SenderName);
                value.Add(mes.SenderEmail);
                value.Add(mes.Messages);
                value.Add(mes.Status);
                value.Add(mes.ReplierId);
                value.Add(mes.IsDeleted);

                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static int DeleteMessage(int id)
        {
            int kt = 0;
            try
            {
                string sql = "sp_deleteMessage";
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

        public static DataTable SearchMessage(string text,int isProgram)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_searchMessage";
                List<string> param = new List<string>();
                param.Add("@value");
                param.Add("@isProgram");

                List<object> value = new List<object>();
                value.Add(text);
                value.Add(isProgram);
                dt = DataConnect.FindData(sql, param, value);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }


        public static DataTable FindMessage(int isProgram)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_findMessage";
                List<string> param = new List<string>();
                param.Add("@isProgram");

                List<object> value = new List<object>();
                value.Add(isProgram);
                dt = DataConnect.FindData(sql, param, value);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }


        public static DataTable GetMessageById(int id)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_findMessageById";
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
