using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;

namespace DataAccessLayer
{
    public class InformationsDA
    {
        public static DataTable GetAllInfor()
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_getAllInformations";
                dt = DataConnect.GetAllData(sql);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }

        


        public static int AddInfor(Models.Informations info)
        {
            int kt = 0;
            try
            {
                string sql = "sp_addNewInformation";
                List<string> param = new List<string>();
                param.Add("@subject");
                param.Add("@textTooltip");
                param.Add("@content");
                param.Add("@parentId");
                param.Add("@position");
                param.Add("@isDeleted");
                param.Add("@links");

                List<object> value = new List<object>();
                value.Add(info.Subject);
                value.Add(info.TextTooltip);
                value.Add(info.Contents);
                value.Add(info.ParentId);
                value.Add(info.Position);
                value.Add(info.IsDeleted);
                value.Add(info.Links);


                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static int EditInfor(Models.Informations info)
        {
            int kt = 0;
            try
            {
                string sql = "sp_editInformation";
                List<string> param = new List<string>();
                param.Add("@id");
                param.Add("@subject");
                param.Add("@textTooltip");
                param.Add("@content");
                param.Add("@parentId");
                param.Add("@position");
                param.Add("@links");
                param.Add("@isDeleted");

                List<object> value = new List<object>();
                value.Add(info.Id);
                value.Add(info.Subject);
                value.Add(info.TextTooltip);
                value.Add(info.Contents);
                value.Add(info.ParentId);
                value.Add(info.Position);
                value.Add(info.Links);
                value.Add(info.IsDeleted);

                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static int DeleteInfor(int id)
        {
            int kt = 0;
            try
            {
                string sql = "sp_deleteInformation";
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

        public static int UpdatePostion(int parentId,int position)
        {
            int kt = 0;
            try
            {
                string sql = "sp_UpdatePosition";
                List<string> param = new List<string>();
                param.Add("@parentId");
                param.Add("@position");

                List<object> value = new List<object>();
                value.Add(parentId);
                value.Add(position);

                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static int UpdatePostionDesc(int parentId, int position)
        {
            int kt = 0;
            try
            {
                string sql = "sp_UpdatePositionDesc";
                List<string> param = new List<string>();
                param.Add("@parentId");
                param.Add("@position");

                List<object> value = new List<object>();
                value.Add(parentId);
                value.Add(position);

                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static DataTable SearchInfor(string text)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_searchInformations";
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

        public static DataTable GetSubmenu(int parentId)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_getSubmenuByParent";
                List<string> param = new List<string>();
                param.Add("@parent");

                List<object> value = new List<object>();
                value.Add(parentId);
                dt = DataConnect.FindData(sql, param, value);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }

        public static DataTable GetMaxPositionBaseOnParent(int parentId)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_getMaxPositionBaseOnParent";
                List<string> param = new List<string>();
                param.Add("@parentId");

                List<object> value = new List<object>();
                value.Add(parentId);
                dt = DataConnect.FindData(sql, param, value);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }

        public static DataTable GetInforById(int id)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_findInformationById";
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

        public static DataTable CheckInforExisted(string text,int ? id)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_checkInformationExisted";
                List<string> param = new List<string>();
                param.Add("@value");
                param.Add("@id");

                List<object> value = new List<object>();
                value.Add(text);
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
