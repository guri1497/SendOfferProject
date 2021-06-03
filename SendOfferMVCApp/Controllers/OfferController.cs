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
    public class OfferController : Controller // Offer controller for controll all Product related stuff
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

        /// <summary>
        /// Send offer to user who listed product
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
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
          
        /// <summary>
        /// Post method of send offer method
        /// </summary>
        /// <param name="showOfferModel"> Offer data recieved from end user</param>
        /// <returns></returns>
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
            return RedirectToAction("Index", "Home");
        }


        /// <summary>
        /// Send counter offer to user vice versa
        /// </summary>
        /// <param name="OfferID"> offer id </param>
        /// <returns>Show send offer popup using SendOffer.cshtml view</returns>
        public ActionResult SendCounterOffer(int OfferID)
        {
            ProductOfferModel model = iProductOfferRepo.GetofferByID(OfferID);
            if (model.Counter == null) // first counter means first barganing
            {
                model.Counter = 1;
            }
            else
            {
                model.Counter += 1; // not first counter
            }
            ShowOfferModel showOfferModel = new ShowOfferModel()
            {
                ID = model.OfferId,
                OfferPrice = model.OfferPrice,
                SenderID = model.ReceiverId,
                RecieverID = model.SenderId,
                ProductId = model.ProductId,
                Status = model.Status,
                Message = model.Message,
                Counter = model.Counter,
            };
            return PartialView(showOfferModel);
        }


        /// <summary>
        /// post method of send counter offer
        /// </summary>
        /// <param name="model">Counter offer data</param>
        /// <returns> index view of home contoller</returns>
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

        
        /// <summary>
        /// ShowNotification method action control 
        /// </summary>
        /// <param name="OfferID"> Offer id of offer</param>
        /// <param name="OfferStatus"> value based of button click </param>
        /// <returns>value of cliked button</returns>
        public string OfferActions(int OfferID, bool OfferStatus) // action button mehod of offer notification 
        {
            string offerStatus = "" ;
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