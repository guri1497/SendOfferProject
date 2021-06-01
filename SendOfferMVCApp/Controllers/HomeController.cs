using Product.IBL;
using Product.Model;
using SendOfferMVCApp.Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SendOfferMVCApp.Controllers
{
    //[Authorize] // authorize the controller for without login 
    public class HomeController : Controller // home controller for all product related task
    {
        IProductRepo iProductRepo;
        IUserRepo iUserRepo;
        IProductOfferRepo iProductOfferRepo;

        public HomeController(IProductRepo _iProductRepo,IUserRepo _iuserRepo, IProductOfferRepo _iProductOfferRepo) // define ctor
        {
            iProductRepo = _iProductRepo;
            iUserRepo = _iuserRepo;
            iProductOfferRepo = _iProductOfferRepo;
        }

        public ActionResult Index() // return the home screen index view
        {
            //int cId = (int)Session["CurrentUserId"];
            //IEnumerable<ProductModel> listOfProduct = iProductRepo.GetAllProduct().Where(x => x.AddedByUserId != cId).ToList(); // get all product data
            return View();
        }

        //public ActionResult GetAllProducts() // get all product data from database and return partial view
        //{
        //    IEnumerable<ProductModel> listOfProduct = iProductRepo.GetAllProduct();
        //    return PartialView("~/Views/Shared/_GetAllProducts.cshtml",listOfProduct);
        //}

        //[HttpPost]
        //public void GetOfferDetails(ProductOfferModel productOfferModel)
        //{
        //    //ProductOfferModel productOfferModel = iProductOfferRepo.Getoffer().Where(x => x.OfferId == 0).FirstOrDefault();
        //}
        

        //public ActionResult OfferPopup()
        //{
        //    return PartialView("~/Views/PartialView/_OfferPopup.cshtml");
        //}

        [AllowAnonymous]
        public ActionResult ContactUs()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult ShowNotification()// showing to user
        {
            int currentUserId = (int)Session["CurrentUserId"]; // getting current user id 
            IEnumerable<ProductOfferModel> productOfferModels = iProductOfferRepo.Getoffer().Where(s => s.SenderId != currentUserId).ToList();  // get all product offer list
            
            IEnumerable<UserModel> userModels = iUserRepo.GetUser().ToList();
            
            IEnumerable<ProductModel> productModels = iProductRepo.GetAllProduct().ToList();
            
            
            var model = (from pom in productOfferModels
                         join um in userModels
                         on pom.SenderId equals um.Id
                         join pm in productModels
                         on pom.ProductId equals pm.Id
                         select new ProductOfferModel()
                         {
                             OfferId = pom.OfferId,
                             OfferPrice = pom.OfferPrice,
                             SenderName = um.Name,
                             ProductName = pm.Name,
                         }).OrderByDescending(p=> p.OfferId).ToList(); // getting all neccesory data from diffrent tables
             
            return View("~/Views/Home/ShowNotification.cshtml",model);
        }
        
    }
}