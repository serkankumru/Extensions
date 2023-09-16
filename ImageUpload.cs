using System;
using DAL;

using System.IO;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace Haberler.Extensions
{
    public static class ImageUpload
    { 
        //int postImages = ImageUpload.ImageAddEditor(ImagePost);
        
        public static int ImageAddEditor(HttpPostedFileBase ImagePost)
        {
            string FilePath = "";
            string Name = "";
            if (ImagePost != null)
            {
                ImageRepository imageRepository = new ImageRepository();
                Name = Guid.NewGuid().ToString() + "_" + Path.GetFileName(ImagePost.FileName);
                FilePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Images"), Name);
                ImagePost.SaveAs(FilePath);
                imageRepository.UploadImageInDataBase(new Image() { Name = Name, FileUrl = FilePath });
                return imageRepository.List().FirstOrDefault(x => x.Name == Name).Id;
            }
            return 1;
        }

        public static int ImageAddNews(HttpPostedFileBase ImagePost)
        {
            string FilePath = "";
            string Name = "";
            if (ImagePost != null)
            {
                ImageRepository imageRepository = new ImageRepository();
                Name = Guid.NewGuid().ToString() + "_" + Path.GetFileName(ImagePost.FileName);
                FilePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Images"), Name);
                ImagePost.SaveAs(FilePath);
                imageRepository.UploadImageInDataBase(new Image() { Name = Name, FileUrl = FilePath });
                return imageRepository.List().FirstOrDefault(x => x.Name == Name).Id;
            }
            return 2;
        }

        public static void ImageRemove(string name)
        {
            File.Delete(HttpContext.Current.Server.MapPath("~/Images/") + name);
        }

        public static void ImageRemove(List<string> name)
        {
            foreach (var item in name)
            {
                File.Delete(HttpContext.Current.Server.MapPath("~/Images/") + item);
            }
        }
    }
}
