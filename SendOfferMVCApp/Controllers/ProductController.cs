using Product.BL;
using Product.IBL;
using Product.Model;
using SendOfferMVCApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SendOfferMVCApp.Controllers
{
    public class ProductController : Controller
    {
        
        IProductRepo iProductRepo;
        IUserRepo iUserRepo;
        IProductOfferRepo iProductOfferRepo;
        IAddressRepo iAddressRepo;

        public ProductController(IUserRepo _iUserRepo,IAddressRepo _iAddressRepo, IProductRepo _iProductRepo, IProductOfferRepo _iProductOfferRepo)
        {
            iUserRepo = _iUserRepo;
            iAddressRepo = _iAddressRepo;
            iProductRepo = _iProductRepo;
            iProductOfferRepo = _iProductOfferRepo;
        }

        public ActionResult GetAllProducts() // get all product data from database and return partial view
        {
            IEnumerable<ProductModel> listOfProduct = iProductRepo.GetAllProduct();
            return PartialView(listOfProduct);
        }

        public ActionResult GetAllProductsForCurrentUser()
        {
            int cId = (int)Session["CurrentUserId"];
            IEnumerable<ProductModel> listOfProduct = iProductRepo.GetAllProduct().Where(x => x.AddedByUserId != cId).ToList(); // get all product data
            return PartialView(listOfProduct);
        }

        [HttpGet]
        public ActionResult AddProduct() // return add product view form
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductModel product) // check model state and return same view with alert
        {
          
            AddressModel addressModel = new AddressModel()
            {
                Id= product.Id,
                AddressLine1=product.Address.AddressLine1,
                AddressLine2 = product.Address.AddressLine2,
                City = product.Address.City,
                State = product.Address.State,
                Country = product.Address.Country
            };
            var currentAddressId  = iAddressRepo.SaveAddress(addressModel);
            var currentAddress = iAddressRepo.GetAddressByID(currentAddressId);

            ProductModel productModel = new ProductModel()
            {
                Id = product.Id,
                Name = product.Name,
                Brand = product.Brand,
                ModelNo = product.ModelNo,
                Category = product.Category,
                Condition = product.Condition,
                BuyNowPrice = product.BuyNowPrice,
                BidDateTime = product.BidDateTime,
                Quantity = product.Quantity,
                ImagePath =product.ImagePath,
                AddressId = currentAddressId,
                AddedByUserId = product.AddedByUserId,
                BidPrice = product.BidPrice,
                Address = currentAddress
            };
            iProductRepo.SaveProduct(productModel);
            ViewBag.AddProductConfirmation = "Record added Succefully.";
            ModelState.Clear();
            return View();
        }

        public ActionResult AddressSave()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddressSave(AddressModel addressModel)
        {
            iAddressRepo.SaveAddress(addressModel);
            return RedirectToAction("AddProduct");
        }

        public string OfferActions(int OfferID, bool OfferStatus)
        {
            var offerStatus = "";
            if (OfferStatus == true)
            {
                offerStatus = "Congratulations,You Accepted the buyer offer.Your Product is sold now.";
                ProductOfferModel productOfferModel = iProductOfferRepo.GetofferByID(OfferID);
                ProductOfferModel productOfferModel1 = new ProductOfferModel()
                {
                    //OfferId = productOfferModel.OfferId,
                    OfferPrice = productOfferModel.OfferPrice,
                    SenderId = productOfferModel.SenderId,
                    ReceiverId = productOfferModel.ReceiverId,
                    ProductId = productOfferModel.ProductId,
                    Status = OfferStatus,
                    Message = productOfferModel.Message
                };
                iProductOfferRepo.UpdateOffer(productOfferModel);
                ProductModel productModel = iProductRepo.GetProductById(productOfferModel.ProductId);


                productModel.ProductStatus = productOfferModel.Status;
                iProductRepo.UpdateProduct(productModel);
            }
            else
            {
                offerStatus = "You Reject this offer.";
                ProductOfferModel productOfferModel = iProductOfferRepo.GetofferByID(OfferID);
                ProductOfferModel productOfferModel1 = new ProductOfferModel()
                {
                    //OfferId = productOfferModel.OfferId,
                    OfferPrice = productOfferModel.OfferPrice,
                    SenderId = productOfferModel.SenderId,
                    ReceiverId = productOfferModel.ReceiverId,
                    ProductId = productOfferModel.ProductId,
                    Status = OfferStatus,
                    Message = productOfferModel.Message
                };
                iProductOfferRepo.UpdateOffer(productOfferModel);
                ProductModel productModel = iProductRepo.GetProductById(productOfferModel.ProductId);


                productModel.ProductStatus = productOfferModel.Status;
                iProductRepo.UpdateProduct(productModel);
            }
            return offerStatus;
        }

    }
}