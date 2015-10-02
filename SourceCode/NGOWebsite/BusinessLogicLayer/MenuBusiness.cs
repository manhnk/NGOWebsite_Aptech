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
    public class MenuBusiness
    {
        private static List<Menu> AddMenuToList(DataTable dt)
        {
            List<Menu> ls = new List<Menu>();
            try
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Menu ad = new Menu()
                    {
                        Id = int.Parse(dt.Rows[i]["Id"].ToString()),
                        Subject = dt.Rows[i]["Subject"].ToString(),
                        TextTooltip = dt.Rows[i]["TextTooltip"].ToString(),
                        Position = int.Parse(dt.Rows[i]["Position"].ToString()),
                        IsDeleted = int.Parse(dt.Rows[i]["IsDeleted"].ToString()),
                        Links = dt.Rows[i]["Links"].ToString()

                    };

                    ls.Add(ad);

                }
            }
            catch (Exception)
            {
                return new List<Menu>();
            }
            return ls;
        }

        public static List<Menu> GetAllMenu()
        {
            DataTable dt = DataAccessLayer.MenuDA.GetAllMenu();
            return AddMenuToList(dt);
        }

        public static List<Menu> SearchMenu(string value)
        {
            DataTable dt = DataAccessLayer.MenuDA.SearchMenu(value);
            return AddMenuToList(dt);
        }

        public static List<Menu> GetMenuById(int id)
        {
            DataTable dt = DataAccessLayer.MenuDA.GetMenuById(id);
            return AddMenuToList(dt);
        }

        public static List<Menu> CheckMenuExisted(string value,int ? id)
        {
            DataTable dt = DataAccessLayer.MenuDA.CheckMenuExisted(value,id);
            return AddMenuToList(dt);
        }

        public int AddMenu(Menu ad)
        {
            int ins = 0;
            try
            {
                ins = DataAccessLayer.MenuDA.AddMenu(ad);
            }
            catch (Exception)
            {
                return 0;
            }

            return ins;

        }

        public int EditMenu(Menu ad)
        {
            int upt = 0;
            try
            {
                upt = DataAccessLayer.MenuDA.EditMenu(ad);
            }
            catch (Exception)
            {
                return 0;
            }
            return upt;
        }

        public int DeleteMenu(int id)
        {
            int del = 0;
            try
            {
                del = DataAccessLayer.MenuDA.DeleteMenu(id);
            }
            catch (Exception)
            {
                return 0;
            }

            return del;
        }
    }
}
