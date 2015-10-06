using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models;

namespace DataAccessLayer
{
    public class ImageGalleryDA
    {
        public static DataTable GetAllImage()
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_getAllImage";
                dt = DataConnect.GetAllData(sql);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }


        public static int AddImage(Models.ImageGallery img)
        {
            int kt = 0;
            try
            {
                string sql = "sp_addNewImage";
                List<string> param = new List<string>();
                param.Add("@programId");
                param.Add("@imagePath");
                param.Add("@description");
                param.Add("@isTopicImage");
                param.Add("@isSlideImage");
                param.Add("@positionInSlide");
                param.Add("@isDeleted");

                List<object> value = new List<object>();
                value.Add(img.ProgramId);
                value.Add(img.ImagePath);
                value.Add(img.Description);
                value.Add(img.IsTopicImage);
                value.Add(img.IsSildeImage);
                value.Add(img.PositionInSilde);
                value.Add(img.IsDeleted);


                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static int EditImage(Models.ImageGallery img)
        {
            int kt = 0;
            try
            {
                string sql = "sp_editImage";
                List<string> param = new List<string>();
                param.Add("@id");
                param.Add("@programId");
                param.Add("@imagePath");
                param.Add("@description");
                param.Add("@isTopicImage");
                param.Add("@isSlideImage");
                param.Add("@positionInSlide");
                param.Add("@isDeleted");

                List<object> value = new List<object>();
                value.Add(img.Id);
                value.Add(img.ProgramId);
                value.Add(img.ImagePath);
                value.Add(img.Description);
                value.Add(img.IsTopicImage);
                value.Add(img.IsSildeImage);
                value.Add(img.PositionInSilde);
                value.Add(img.IsDeleted);


                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }



        public static int UpdateIsTopicImage(int proId)
        {
            int kt = 0;
            try
            {
                string sql = "sp_updateIsTopicImage";
                List<string> param = new List<string>();
                param.Add("@proId");

                List<object> value = new List<object>();
                value.Add(proId);

                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }

        public static int UpdateIsTopicImageForOldProgram(int proId,int id)
        {
            int kt = 0;
            try
            {
                string sql = "sp_setImageTopicForProgramOld";
                List<string> param = new List<string>();
                param.Add("@proId");
                param.Add("@id");

                List<object> value = new List<object>();
                value.Add(proId);
                value.Add(id);

                kt = DataConnect.CRUDData(sql, param, value);
            }
            catch (Exception)
            {
                return 0;
            }
            return kt;
        }
        public static int DeleteImage(int id)
        {
            int kt = 0;
            try
            {
                string sql = "sp_deleteImage";
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

        public static DataTable GetImageById(int id)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_findImageById";
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

        public static DataTable GetImageByProgram(int id)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_findImageByProgram";
                List<string> param = new List<string>();
                param.Add("@programId");

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

        public static DataTable GetImageTopic(int id)
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_findTopicImage";
                List<string> param = new List<string>();
                param.Add("@programId");

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

        public static DataTable GetImageSilde()
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_findTopicImage";

                dt = DataConnect.FindData(sql, null, null);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }

        public static DataTable GetProgramImage()
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_getProgramImage";

                dt = DataConnect.FindData(sql, null, null);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }


        public static DataTable GetImageTopicPrograms()
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_getImageTopicPrograms";

                dt = DataConnect.FindData(sql, null, null);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }
        public static DataTable GetImageOthers()
        {
            DataTable dt = null;
            try
            {
                string sql = "sp_getImageOthers";

                dt = DataConnect.FindData(sql, null, null);
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }


    }
}
