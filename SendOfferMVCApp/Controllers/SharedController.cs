using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SendOfferMVCApp.Controllers
{
    public class SharedController : Controller // shared controller for controll all similar actions
    {
        public JsonResult UploadImage()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            try
            {
                var file = Request.Files[0]; // recieve request from formdata instance in add product view jquery method

                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName); // save dummy data with image name

                var path = Path.Combine(Server.MapPath("~/content/images/"), fileName); // save path
                 
                file.SaveAs(path); // saing file

                result.Data = new { Success = true, ImagePath = string.Format("/content/images/{0}", fileName) }; // return image path

                //var newImage = new Image() { Name = fileName };

                //if (ImagesService.Instance.SaveNewImage(newImage))
                //{
                //    result.Data = new { Success = true, Image = fileName, File = newImage.ID, ImageURL = string.Format("{0}{1}", Variables.ImageFolderPath, fileName) };
                //}
                //else
                //{
                //    result.Data = new { success = false, Message = new HttpStatusCodeResult(500) };
                //}
            }
            catch (Exception ex)
            {
                result.Data = new { Success = false, Message = ex.Message };
            }

            return result;
        }
    }
}