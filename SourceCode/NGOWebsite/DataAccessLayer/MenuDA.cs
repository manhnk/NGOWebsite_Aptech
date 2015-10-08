using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;

namespace DataAccessLayer
{
    public class MenuDA
    {
        public static DataTable GetAllMenu()
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_getAllMenu";
                dt = DataConnect.GetAllData(sql);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }

        public static DataTable GetAllMenuPostionNotNull()
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_getAllMenuWithPositionNotNull";
                dt = DataConnect.GetAllData(sql);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }

        public static DataTable GetMaxPostion()
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_getMaxPositionMenu";
                dt = DataConnect.FindData(sql, null, null);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }

        public static int UpdatePostion(int position)
        {
            int kt = 0;
            try
            {
                string sql = "sp_UpdatePositionMenu";
                List<string> param = new List<string>();
                param.Add("@position");

                List<object> value = new List<object>();
                value.Add(position);

                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static int UpdatePostionDesc(int position)
        {
            int kt = 0;
            try
            {
                string sql = "sp_UpdatePositionMenuDesc";
                List<string> param = new List<string>();
                param.Add("@position");

                List<object> value = new List<object>();
                value.Add(position);

                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }
      

        public static int AddMenu(Models.Menu menu)
        {
            int kt = 0;
            try
            {
                string sql = "sp_addNewMenu";
                List<string> param = new List<string>();
                param.Add("@subject");
                param.Add("@textTooltip");
                param.Add("@position");
                param.Add("@isDeleted");
                param.Add("@links");

                List<object> value = new List<object>();
                value.Add(menu.Subject);
                value.Add(menu.TextTooltip);
                value.Add(menu.Position);
                value.Add(menu.IsDeleted);
                value.Add(menu.Links);


                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static int EditMenu(Models.Menu menu)
        {
            int kt = 0;
            try
            {
                string sql = "sp_editMenu";
                List<string> param = new List<string>();
                param.Add("@id");
                param.Add("@subject");
                param.Add("@textTooltip");
                param.Add("@position ");
                param.Add("@isDeleted");
                param.Add("@links");

                List<object> value = new List<object>();
                value.Add(menu.Id);
                value.Add(menu.Subject);
                value.Add(menu.TextTooltip);
                value.Add(menu.Position);
                value.Add(menu.IsDeleted);
                value.Add(menu.Links);

                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static int DeleteMenu(int id)
        {
            int kt = 0;
            try
            {
                string sql = "sp_deleteMenu";
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

        public static DataTable SearchMenu(string text)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_searchMenu";
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

        public static DataTable GetMenuById(int id)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_findMenuById";
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

        public static DataTable CheckMenuExisted(string text,int ? id)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_checkMenuExisted";
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
