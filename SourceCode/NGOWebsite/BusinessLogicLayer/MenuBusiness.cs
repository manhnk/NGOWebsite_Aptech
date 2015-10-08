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
                    int? position = null;
                    if (dt.Rows[i]["Position"].ToString() != null && dt.Rows[i]["Position"].ToString() != "")
                    {
                        position = int.Parse(dt.Rows[i]["Position"].ToString());
                    }
                    Menu ad = new Menu()
                    {
                        Id = int.Parse(dt.Rows[i]["Id"].ToString()),
                        Subject = dt.Rows[i]["Subject"].ToString(),
                        TextTooltip = dt.Rows[i]["TextTooltip"].ToString(),
                        Position = position,
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

        public static List<Menu> GetAllMenuPostionNotNull()
        {
            DataTable dt = DataAccessLayer.MenuDA.GetAllMenuPostionNotNull();
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

        public static int? GetMaxPosition()
        {
            DataTable dt = DataAccessLayer.MenuDA.GetMaxPostion();
            int? kt = null;
            if (dt.Rows[0]["MaxPosition"].ToString() != "")
            {
                kt = int.Parse(dt.Rows[0]["MaxPosition"].ToString());
            }
            return kt;
        }

        public static List<Menu> CheckMenuExisted(string value,int ? id)
        {
            DataTable dt = DataAccessLayer.MenuDA.CheckMenuExisted(value,id);
            return AddMenuToList(dt);
        }

        public static int UpdatePostion(int position)
        {
            int upt = 0;
            try
            {
                upt = DataAccessLayer.MenuDA.UpdatePostion(position);
            }
            catch (Exception)
            {
                return 0;
            }
            return upt;
        }

        public static int UpdatePostionDesc(int position)
        {
            int upt = 0;
            try
            {
                upt = DataAccessLayer.MenuDA.UpdatePostionDesc(position);
            }
            catch (Exception)
            {
                return 0;
            }
            return upt;
        }

        public static int AddMenu(Menu ad)
        {
            int ins = 0;
            try
            {
                int? maxPos = GetMaxPosition();
                if (ad.Position != null)
                {
                    if (maxPos == null)
                    {
                        ad.Position = 1;
                    }
                    else
                    {
                        if (ad.Position > maxPos)
                        {
                            ad.Position = maxPos + 1;
                        }
                        else {
                            UpdatePostion((int)ad.Position);
                        }
                    }
                }
                ins = DataAccessLayer.MenuDA.AddMenu(ad);
            }
            catch (Exception)
            {
                return 0;
            }

            return ins;

        }

        public static int EditMenu(Menu ad)
        {
            int upt = 0;
            int check = 0;
            try
            {
                Menu mOld=MenuBusiness.GetMenuById(ad.Id)[0];
                int? maxPos = GetMaxPosition();

                if (ad.Position != null)
                {
                    if (maxPos == null)
                    {
                        ad.Position = 1;
                    }
                    else
                    {
                        if (mOld.Position != null)
                        {

                            if (ad.Position > maxPos)
                            {
                                UpdatePostionDesc((int)mOld.Position);
                                ad.Position = maxPos;
                            }
                            else
                            {
                                UpdatePostion((int)ad.Position);
                                check = 1;
                            }
                        }
                        else
                        {
                            if (ad.Position > maxPos)
                            {
                                ad.Position = maxPos + 1;
                            }
                            else
                            {
                                int kt = UpdatePostion((int)ad.Position);
                            }
                        }
                    }
                }
                upt = DataAccessLayer.MenuDA.EditMenu(ad);
                if (upt > 0 && check == 1)
                {
                    UpdatePostionDesc((int)mOld.Position);
                }
            }
            catch (Exception)
            {
                return 0;
            }
            return upt;
        }

        public static int DeleteMenu(int id)
        {
            int del = 0;
            try
            {
                Menu infor = MenuBusiness.GetMenuById(id)[0];
                del = DataAccessLayer.MenuDA.DeleteMenu(id);
                if (del > 0)
                {
                    if (infor.Position != null)
                    {
                        UpdatePostionDesc((int)infor.Position);
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }

            return del;
        }
    }
}
