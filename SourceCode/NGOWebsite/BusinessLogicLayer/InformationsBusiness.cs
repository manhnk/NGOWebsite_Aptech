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
    public class InformationsBusiness
    {
        private static List<Informations> AddInformationToList(DataTable dt)
        {
            List<Informations> ls = new List<Informations>();
            try
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int? position = null;
                    int? parentId = null;
                    if (dt.Rows[i]["Position"].ToString() != "")
                    {
                        position = int.Parse(dt.Rows[i]["Position"].ToString());
                    }
                    if (dt.Rows[i]["ParentId"].ToString() != "")
                    {
                        parentId = int.Parse(dt.Rows[i]["ParentId"].ToString());
                    }
                    Informations ad = new Informations()
                    {
                        Id = int.Parse(dt.Rows[i]["Id"].ToString()),
                        Subject = dt.Rows[i]["Subject"].ToString(),
                        TextTooltip = dt.Rows[i]["TextTooltip"].ToString(),
                        Contents = dt.Rows[i]["Contents"].ToString(),
                        ParentId = parentId,
                        ParentName = dt.Rows[i]["ParentName"].ToString(),
                        Position = position,
                        IsDeleted = int.Parse(dt.Rows[i]["IsDeleted"].ToString()),
                        Links = dt.Rows[i]["Links"].ToString()
                    };

                    ls.Add(ad);

                }
            }
            catch (Exception)
            {
                return new List<Informations>();
            }
            return ls;
        }

        public static List<Informations> GetAllInformations()
        {
            DataTable dt = DataAccessLayer.InformationsDA.GetAllInfor();
            return AddInformationToList(dt);
        }

        public static List<Informations> SearchInformations(string value)
        {
            DataTable dt = DataAccessLayer.InformationsDA.SearchInfor(value);
            return AddInformationToList(dt);
        }

        public static List<Informations> GetInformationsById(int id)
        {
            DataTable dt = DataAccessLayer.InformationsDA.GetInforById(id);
            return AddInformationToList(dt);
        }

        public static int? GetMaxPositionBaseOnParent(int parentId)
        {
            DataTable dt = DataAccessLayer.InformationsDA.GetMaxPositionBaseOnParent(parentId);
            int? kt = null;
            if (dt.Rows[0]["MaxPosition"].ToString() != "")
            {
                kt = int.Parse(dt.Rows[0]["MaxPosition"].ToString());
            }
            return kt;
        }

        public static List<Informations> CheckInformationExisted(string value, int? id)
        {
            DataTable dt = DataAccessLayer.InformationsDA.CheckInforExisted(value, id);
            return AddInformationToList(dt);
        }

        public static int UpdatePostion(int parentId, int position)
        {
            int upt = 0;
            try
            {
                upt = DataAccessLayer.InformationsDA.UpdatePostion(parentId, position);
            }
            catch (Exception)
            {
                return 0;
            }
            return upt;
        }

        public static int AddInformations(Informations ad)
        {
            int ins = 0;
            try
            {
                if (ad.ParentId != null)
                {
                    int? maxPos = GetMaxPositionBaseOnParent((int)(ad.ParentId));
                    if (maxPos == null)
                    {
                        ad.Position = 1;
                    }
                    else
                    {
                        if (ad.Position == null)
                        {
                            ad.Position = maxPos + 1;
                        }
                        else
                        {
                            if (ad.Position > maxPos)
                            {
                                ad.Position = maxPos + 1;
                            }
                            else
                            {
                                int kt = UpdatePostion((int)ad.ParentId, (int)ad.Position);
                            }
                        }
                    }

                }
                ins = DataAccessLayer.InformationsDA.AddInfor(ad);
            }
            catch (Exception)
            {
                return 0;
            }

            return ins;

        }

        public static int EditInformations(Informations ad)
        {
            int upt = 0;
            try
            {
                upt = DataAccessLayer.InformationsDA.EditInfor(ad);
            }
            catch (Exception)
            {
                return 0;
            }
            return upt;
        }

        public static int DeleteInformations(int id)
        {
            int del = 0;
            try
            {
                del = DataAccessLayer.InformationsDA.DeleteInfor(id);
            }
            catch (Exception)
            {
                return 0;
            }

            return del;
        }
    }
}
