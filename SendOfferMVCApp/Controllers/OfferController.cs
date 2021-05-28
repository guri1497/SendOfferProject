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
            ProductModel productModel = iProductRepo.GetProductById(ID);
            ShowOfferModel model = new ShowOfferModel() {
                ProductId = productModel.Id,
                RecieverID = (int)productModel.AddedByUserId,
        };
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult SendOffer(ShowOfferModel showOfferModel)
        {
            var product = iProductRepo.GetProductById(showOfferModel.ProductId);
            ProductOfferModel productOfferModel = new ProductOfferModel()
            {
                OfferId = showOfferModel.ID,
                OfferPrice = showOfferModel.OfferPrice,
                SenderId = showOfferModel.SenderID,
                ReceiverId = showOfferModel.RecieverID,
                ProductId = showOfferModel.ProductId
            };
            iProductOfferRepo.SaveOffer(productOfferModel);
            return RedirectToAction("Index","Home");
        }
    }
}