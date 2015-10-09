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
        private static List<Message> AddMessageToList(DataTable dt,string flag)
        {
            List<Message> ls = new List<Message>();
            try
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string programName = null;
                    if (flag ==null)
                    {
                        programName= dt.Rows[i]["Name"].ToString();
                    }
                    int? programId = null;
                    int? replierId = null;
                    if (dt.Rows[i]["ProgramId"].ToString() != null && dt.Rows[i]["ProgramId"].ToString()!="")
                    {
                        programId = int.Parse(dt.Rows[i]["ProgramId"].ToString());
                    }
                    if (dt.Rows[i]["Replier"].ToString() != null && dt.Rows[i]["Replier"].ToString() != "")
                    {
                        replierId = int.Parse(dt.Rows[i]["Replier"].ToString());
                    }

                    Message ad = new Message()
                    {
                        Id = int.Parse(dt.Rows[i]["Id"].ToString()),
                        ProgramId = programId,
                        ProgramName =programName,
                        SenderName = dt.Rows[i]["SenderName"].ToString(),
                        SenderEmail = dt.Rows[i]["SenderEmail"].ToString(),
                        Messages = dt.Rows[i]["Message"].ToString(),
                        Status = int.Parse(dt.Rows[i]["Status"].ToString()),
                        ReplierId = replierId,
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

        private static List<Message> AddMessageToList2(DataTable dt)
        {
            List<Message> ls = new List<Message>();
            try
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Message ad = new Message()
                    {
                        ProgramId = int.Parse(dt.Rows[i]["ProgramId"].ToString()),
                        ProgramName = dt.Rows[i]["Name"].ToString(),
                        TotalMessage = int.Parse(dt.Rows[i]["TotalMessage"].ToString()),
                        TotalNewMessage = int.Parse(dt.Rows[i]["TotalNewMessage"].ToString()),
                        TotalReadMessage = int.Parse(dt.Rows[i]["TotalReadMessage"].ToString()),
                        TotalRepliedMessage = int.Parse(dt.Rows[i]["TotalRepliedMessage"].ToString()),
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
            return AddMessageToList(dt,null);
        }

        public static List<Message> SearchMessage(string value,int isProgram)
        {
            DataTable dt = DataAccessLayer.MessageDA.SearchMessage(value,isProgram);
            return AddMessageToList(dt,null);
        }

        public static List<Message> GetMessageByProgram(int programId)
        {
            DataTable dt = DataAccessLayer.MessageDA.GetMessageByProgram(programId);
            return AddMessageToList(dt,null);
        }

        public static List<Message> GetOtherMessage()
        {
            DataTable dt = DataAccessLayer.MessageDA.GetOtherMessage();
            return AddMessageToList(dt,"other");
        }

        public static List<Message> GetProgramMessage()
        {
            DataTable dt = DataAccessLayer.MessageDA.GetProgramMessage();
            return AddMessageToList2(dt);
        }

        public static List<Message> GetMessageById(int id)
        {
            DataTable dt = DataAccessLayer.MessageDA.GetMessageById(id);
            return AddMessageToList(dt,null);
        }


        public static int AddMessage(Message ad)
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

        public static int EditMessage(Message ad)
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

        public static int DeleteMessage(int id)
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
