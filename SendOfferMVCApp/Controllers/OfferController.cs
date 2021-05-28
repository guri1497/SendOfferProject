using Product.IBL;
using Product.Model;
using SendOfferMVCApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SendOfferMVCApp.Controllers
{
    public class OfferController : Controller
    {

        IProductRepo iProductRepo;
        IUserRepo iUserRepo;
        IProductOfferRepo iProductOfferRepo;

        public OfferController(IProductRepo _iProductRepo, IUserRepo _iuserRepo, IProductOfferRepo _iProductOfferRepo) // define ctor
        {
            iProductRepo = _iProductRepo;
            iUserRepo = _iuserRepo;
            iProductOfferRepo = _iProductOfferRepo;
        }

        [HttpGet]
        public ActionResult SendOffer(int ID)
        {
            var model = new ShowOfferModel();
            model.ProductId = ID;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult SendOffer(ShowOfferModel showOfferModel)
        {
            var product = iProductRepo.GetProductById(showOfferModel.ProductId);
            ProductOfferModel newSOM = new ProductOfferModel();
            newSOM.OfferPrice = showOfferModel.OfferPrice;
            newSOM.ProductId = product.Id;
            newSOM.SenderId = (int)Session["CurrentUserId"];
            newSOM.ReceiverId = (int)product.AddedByUserId;
            iProductOfferRepo.SaveOffer(newSOM);
            return RedirectToAction("Index");
        }
    }
}