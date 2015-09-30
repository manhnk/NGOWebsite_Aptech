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
    public class MessageBusiness
    {
        private static List<Message> AddMessageToList(DataTable dt)
        {
            List<Message> ls = new List<Message>();
            try
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Message ad = new Message()
                    {
                        Id = int.Parse(dt.Rows[i]["Id"].ToString()),
                        ProgramId = int.Parse(dt.Rows[i]["ProgramId"].ToString()),
                        ProgramName = dt.Rows[i]["Name"].ToString(),
                        SenderName = dt.Rows[i]["SenderName"].ToString(),
                        SenderEmail = dt.Rows[i]["SenderEmail"].ToString(),
                        Messages = dt.Rows[i]["Message"].ToString(),
                        Status = int.Parse(dt.Rows[i]["Status"].ToString()),
                        ReplierId = int.Parse(dt.Rows[i]["Repler"].ToString()),
                        Replier = dt.Rows[i]["UserName"].ToString(),
                        IsDeleted = int.Parse(dt.Rows[i]["IsDeleted"].ToString())
                    };

                    ls.Add(ad);

                }
            }
            catch (Exception)
            {
                return new List<Message>();
            }
            return ls;
        }

        public static List<Message> GetAllMessage()
        {
            DataTable dt = DataAccessLayer.MessageDA.GetAllMessage();
            return AddMessageToList(dt);
        }

        public static List<Message> SearchMessage(string value,int isProgram)
        {
            DataTable dt = DataAccessLayer.MessageDA.SearchMessage(value,isProgram);
            return AddMessageToList(dt);
        }

        public static List<Message> FindMessage(int isProgram)
        {
            DataTable dt = DataAccessLayer.MessageDA.FindMessage(isProgram);
            return AddMessageToList(dt);
        }

        public static List<Message> GetMessageById(int id)
        {
            DataTable dt = DataAccessLayer.MessageDA.GetMessageById(id);
            return AddMessageToList(dt);
        }


        public int AddMessage(Message ad)
        {
            int ins = 0;
            try
            {
                ins = DataAccessLayer.MessageDA.AddMessage(ad);
            }
            catch (Exception)
            {
                return 0;
            }

            return ins;

        }

        public int EditMessage(Message ad)
        {
            int upt = 0;
            try
            {
                upt = DataAccessLayer.MessageDA.EditMessage(ad);
            }
            catch (Exception)
            {
                return 0;
            }
            return upt;
        }

        public int DeleteMessage(int id)
        {
            int del = 0;
            try
            {
                del = DataAccessLayer.MessageDA.DeleteMessage(id);
            }
            catch (Exception)
            {
                return 0;
            }

            return del;
        }
    }
}
