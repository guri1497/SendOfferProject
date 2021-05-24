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
        AddressRepo addressRepo;

        [HttpGet]
        public ActionResult AddProduct() // return add product view form
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductModel product) // check model state and return same view with alert
        {
            //var product = new ProductModel();
            //product.Address.AddressLine1 = newProductAddressModel.AddressLine1;
            //product.Address.AddressLine2 = newProductAddressModel.AddressLine2;
            //product.Address.City = newProductAddressModel.City;
            //product.Address.State = newProductAddressModel.State;
            //product.Address.Country = newProductAddressModel.Country;
            //product.Name = newProductAddressModel.Name;
            //product.BidDateTime = newProductAddressModel.BidDateTime;
            //product.BidPrice = newProductAddressModel.BidPrice;
            //product.Brand = newProductAddressModel.Brand;
            

            //string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
            //string fileExtension = Path.GetExtension(product.ImageFile.FileName);
            //fileName = fileName + DateTime.Now.ToString("yymmssfff") + fileExtension;
            //product.ImagePath = "~/Image/" + fileName;
            //fileName = Path.Combine(Server.MapPath("~/Image"), fileName);
            //product.ImageFile.SaveAs(fileName);
            addressRepo.SaveAddress(product.Address);
           // product.AddressId = product.AddressId;
           // var newAddress = product.Address;
            
            iProductRepo.AddProduct(product);
            ViewBag.AddProductConfirmation = "Record added Succefully.";
            ModelState.Clear();
            return View();
        }
    }
}