﻿using Product.IBL;
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
        public ActionResult SendOffer(int ID) // open popup on send offer button click
        {
            ProductModel productModel = iProductRepo.GetProductById(ID);
            ShowOfferModel model = new ShowOfferModel() {
                ProductId = productModel.Id,
                RecieverID = (int)productModel.AddedByUserId,
        };
            return PartialView(model);
        }

        public ActionResult SendCounterOffer(int OfferID)
        {
            ProductOfferModel productOfferModel = iProductOfferRepo.GetofferByID(OfferID);
            if (productOfferModel.Counter == null)
            {
                productOfferModel.Counter = 1;
            }
            else
            {
                productOfferModel.Counter += 1;
            }
            ShowOfferModel showOfferModel = new ShowOfferModel()
            {
                ProductId = productOfferModel.ProductId,
                SenderID = productOfferModel.ReceiverId,
                RecieverID = productOfferModel.SenderId,
                Counter = productOfferModel.Counter
            };
            return PartialView("~/Views/Offer/SendOffer.cshtml",showOfferModel);
        }

        [HttpPost]
        public ActionResult SendCounterOffer(ShowOfferModel model)
        {
            ProductOfferModel productOfferModel = new ProductOfferModel()
            {
                OfferId = model.ID,
                OfferPrice = model.OfferPrice,
                SenderId = model.SenderID,
                ReceiverId = model.RecieverID,
                ProductId = model.ProductId,
                Status = model.Status,
                Message = model.Message,
                Counter = model.Counter,
            };
            iProductOfferRepo.SaveOffer(productOfferModel);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult SendOffer(ShowOfferModel showOfferModel) // open popup on send offer button click
        {
            //var product = iProductRepo.GetProductById(showOfferModel.ProductId);
            ProductOfferModel productOfferModel = new ProductOfferModel()
            {
                OfferId = showOfferModel.ID,
                OfferPrice = showOfferModel.OfferPrice,
                SenderId = showOfferModel.SenderID,
                ReceiverId = showOfferModel.RecieverID,
                ProductId = showOfferModel.ProductId,
                Status = showOfferModel.Status,
                Message = showOfferModel.Message,
                Counter = showOfferModel.Counter,
            };
            iProductOfferRepo.SaveOffer(productOfferModel);
            return RedirectToAction("Index","Home");
        }

        public string OfferActions(int OfferID, bool OfferStatus) // action button mehod of offer notification 
        {
            string offerStatus = "";
            if (OfferStatus == true)
            {
               
                ProductOfferModel productOfferModel = iProductOfferRepo.GetofferByID(OfferID); //get offer by id
                ProductOfferModel productOfferModel1 = new ProductOfferModel() 
                {
                    OfferId = productOfferModel.OfferId,
                    OfferPrice = productOfferModel.OfferPrice,
                    SenderId = productOfferModel.SenderId,
                    ReceiverId = productOfferModel.ReceiverId,
                    ProductId = productOfferModel.ProductId,
                    Status = OfferStatus,
                    Message = productOfferModel.Message
                };

                iProductOfferRepo.UpdateOffer(productOfferModel1);
                return offerStatus = "true";
            }
            else
            {
                ProductOfferModel productOfferModel = iProductOfferRepo.GetofferByID(OfferID);
                ProductOfferModel productOfferModel1 = new ProductOfferModel()
                {
                    OfferId = productOfferModel.OfferId,
                    OfferPrice = productOfferModel.OfferPrice,
                    SenderId = productOfferModel.SenderId,
                    ReceiverId = productOfferModel.ReceiverId,
                    ProductId = productOfferModel.ProductId,
                    Status = OfferStatus,
                    Message = productOfferModel.Message
                };
                iProductOfferRepo.UpdateOffer(productOfferModel1);
                return offerStatus = "false";
            }
            
        }

    }
}