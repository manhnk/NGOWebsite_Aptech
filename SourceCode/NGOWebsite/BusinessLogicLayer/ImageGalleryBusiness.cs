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
    public class ImageGalleryBusiness
    {
        private static List<ImageGallery> AddImageGalleryToList(DataTable dt)
        {
            List<ImageGallery> ls = new List<ImageGallery>();
            try
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ImageGallery ad = new ImageGallery()
                    {
                        Id = int.Parse(dt.Rows[i]["Id"].ToString()),
                        ProgramId = int.Parse(dt.Rows[i]["ProgramId"].ToString()),
                        ProgramName = dt.Rows[i]["Name"].ToString(),
                        ImagePath = dt.Rows[i]["ImagePath"].ToString(),
                        Description = dt.Rows[i]["Description"].ToString(),
                        IsTopicImage = int.Parse(dt.Rows[i]["IsTopicImage"].ToString()),
                        IsSildeImage = int.Parse(dt.Rows[i]["IsSlideImage"].ToString()),
                        PositionInSilde = int.Parse(dt.Rows[i]["PositionInSlide"].ToString()),
                        IsDeleted = int.Parse(dt.Rows[i]["IsDeleted"].ToString()),
                       
                    };

                    ls.Add(ad);

                }
            }
            catch (Exception)
            {
                return new List<ImageGallery>();
            }
            return ls;
        }

        public static List<ImageGallery> GetAllImageGallery()
        {
            DataTable dt = DataAccessLayer.ImageGalleryDA.GetAllImage();
            return AddImageGalleryToList(dt);
        }

        public static List<ImageGallery> GetImageGalleryById(int id)
        {
            DataTable dt = DataAccessLayer.ImageGalleryDA.GetImageById(id);
            return AddImageGalleryToList(dt);
        }

        public static List<ImageGallery> GetImageGalleryByProgram(int id)
        {
            DataTable dt = DataAccessLayer.ImageGalleryDA.GetImageByProgram(id);
            return AddImageGalleryToList(dt);
        }

        public static List<ImageGallery> GetImageTopic(int id)
        {
            DataTable dt = DataAccessLayer.ImageGalleryDA.GetImageTopic(id);
            return AddImageGalleryToList(dt);
        }

        public static List<ImageGallery> GetImageSlide()
        {
            DataTable dt = DataAccessLayer.ImageGalleryDA.GetImageSilde();
            return AddImageGalleryToList(dt);
        }

        public int AddImageGallery(ImageGallery ad)
        {
            int ins = 0;
            try
            {
                ins = DataAccessLayer.ImageGalleryDA.AddImage(ad);
            }
            catch (Exception)
            {
                return 0;
            }

            return ins;

        }

        public int EditImageGallery(ImageGallery ad)
        {
            int upt = 0;
            try
            {
                upt = DataAccessLayer.ImageGalleryDA.EditImage(ad);
            }
            catch (Exception)
            {
                return 0;
            }
            return upt;
        }

        public int DeleteImageGallery(int id)
        {
            int del = 0;
            try
            {
                del = DataAccessLayer.ImageGalleryDA.DeleteImage(id);
            }
            catch (Exception)
            {
                return 0;
            }

            return del;
        }
    }
}
