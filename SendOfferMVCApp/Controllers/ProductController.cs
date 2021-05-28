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

        public ProductController(IAddressRepo addressRepo, IProductRepo productRepo)
        {
            iAddressRepo = addressRepo;
            iProductRepo = productRepo;
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


    }
}