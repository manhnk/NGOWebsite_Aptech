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
                    Nullable<int> proId = null;
                    Nullable<int> isTopicImg = null;
                    Nullable<int> isSlideImg = null;
                    Nullable<int> position = null;
                    if (dt.Rows[i]["ProgramId"].ToString() != "")
                    {
                        proId = int.Parse(dt.Rows[i]["ProgramId"].ToString());
                    }
                    if (dt.Rows[i]["IsTopicImage"].ToString() != "")
                    {
                        isTopicImg = int.Parse(dt.Rows[i]["IsTopicImage"].ToString());
                    }
                    if (dt.Rows[i]["IsSlideImage"].ToString() != "")
                    {
                        isSlideImg = int.Parse(dt.Rows[i]["IsSlideImage"].ToString());
                    }
                    if (dt.Rows[i]["PositionInSlide"].ToString() != "")
                    {
                        position = int.Parse(dt.Rows[i]["PositionInSlide"].ToString());
                    }


                    ImageGallery ad = new ImageGallery()
                    {
                        Id = int.Parse(dt.Rows[i]["Id"].ToString()),
                        ProgramId = proId,
                        ProgramName = dt.Rows[i]["Name"].ToString(),
                        ImagePath = dt.Rows[i]["ImagePath"].ToString(),
                        Description = dt.Rows[i]["Description"].ToString(),
                        IsTopicImage = isTopicImg,
                        IsSildeImage = isSlideImg,
                        PositionInSilde = position,
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

        private static List<ImageGallery> AddImageGalleryToList2(DataTable dt, string flag)
        {
            List<ImageGallery> ls = new List<ImageGallery>();
            try
            {
                if (flag == "getImageProgram")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ImageGallery ad = new ImageGallery()
                        {
                         
                            ProgramId=int.Parse(dt.Rows[i]["ProgramId"].ToString()),
                            ProgramName = dt.Rows[i]["Name"].ToString(),
                            TotalImage = int.Parse(dt.Rows[i]["TotalImage"].ToString()),
                        };

                        ls.Add(ad);
                    }
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ImageGallery ad = new ImageGallery()
                        {
                            ProgramId = int.Parse(dt.Rows[i]["ProgramId"].ToString()),
                            ProgramName = dt.Rows[i]["Name"].ToString(),
                            ImagePath = dt.Rows[i]["ImagePath"].ToString()
                        };

                        ls.Add(ad);
                    }
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

        public static List<ImageGallery> GetProgramImage()
        {
            DataTable dt = DataAccessLayer.ImageGalleryDA.GetProgramImage();
            return AddImageGalleryToList2(dt,"getImageProgram");
        }
        public static List<ImageGallery> GetImageTopicPrograms()
        {
            DataTable dt = DataAccessLayer.ImageGalleryDA.GetImageTopicPrograms();
            return AddImageGalleryToList2(dt,"getTopicImage");
        }

        public static List<ImageGallery> GetImageOthers()
        {
            DataTable dt = DataAccessLayer.ImageGalleryDA.GetImageOthers();
            return AddImageGalleryToList(dt);
        }

        public static int AddImageGallery(ImageGallery ad)
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

        public static int UpdateIsTopicImage(int proId)
        {
            int ins = 0;
            try
            {
                ins = DataAccessLayer.ImageGalleryDA.UpdateIsTopicImage(proId);
            }
            catch (Exception)
            {
                return 0;
            }
            return ins;
        }

        public static int UpdateIsTopicImageForOldProgram(int proId,int id)
        {
            int ins = 0;
            try
            {
                ins = DataAccessLayer.ImageGalleryDA.UpdateIsTopicImageForOldProgram(proId,id);
            }
            catch (Exception)
            {
                return 0;
            }
            return ins;
        }
        
        public static int EditImageGallery(ImageGallery ad)
        {
            int upt = 0;
            try
            {
                List<ImageGallery> lsOld = ImageGalleryBusiness.GetImageGalleryById(ad.Id);
                ImageGallery imgOld = lsOld[0];
                if (imgOld.IsTopicImage == 1 && imgOld.ProgramId!=ad.ProgramId)
                {
                   int kt= UpdateIsTopicImageForOldProgram((int)imgOld.ProgramId,imgOld.Id);
                }

                if (ad.ProgramId != null)
                {
                    List<ImageGallery> ls = ImageGalleryBusiness.GetImageTopic((int)ad.ProgramId);
                    if (ad.IsTopicImage == 1)
                    {
                        if (ls.Count > 0)
                        {
                            UpdateIsTopicImage((int)ad.ProgramId);
                        }
                    }
                    else
                    {
                        if (ls.Count == 0)
                        {
                            ad.IsTopicImage = 1;
                        }
                       
                    }
                }
               
                upt = DataAccessLayer.ImageGalleryDA.EditImage(ad);
            }
            catch (Exception)
            {
                return 0;
            }
            return upt;
        }

        public static int DeleteImageGallery(int id)
        {
            int del = 0;
            try
            {
                List<ImageGallery> lsOld = ImageGalleryBusiness.GetImageGalleryById(id);
                ImageGallery imgOld = lsOld[0];
                if (imgOld.IsTopicImage == 1)
                {
                    int kt = UpdateIsTopicImageForOldProgram((int)imgOld.ProgramId, imgOld.Id);
                }
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
