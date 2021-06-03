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
    public class ProductController : Controller // home controller for controll all menu
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

        /// <summary>
        /// Get all products for current login user and this method is render in index view of home controller 
        /// </summary>
        /// <returns>filterd list of products</returns>
        public ActionResult GetAllProductsForCurrentUser()
        {
            int cId = (int)Session["CurrentUserId"]; // current login user id
            IEnumerable<ProductModel> listOfProduct = iProductRepo.GetAllProduct().Where(x => x.AddedByUserId != cId).ToList();
            return PartialView(listOfProduct);
        }

        public ActionResult CehckProductStatus() // testing pending not in working ----------------------
        {
            List<ProductModel> productModel = iProductRepo.GetAllProduct().Where(p => p.ProductStatus == true).ToList();

            return View();
        }

        /// <summary>
        /// Add new product method
        /// </summary>
        /// <returns>form for adding new product</returns>
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        /// <summary>
        /// Post method of addproduct
        /// </summary>
        /// <param name="product">takes product data received from end user</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddProduct(ProductModel product) 
        {
            AddressModel addressModel = new AddressModel() //first saving address due to forieng key 
            {
                Id= product.Id,
                AddressLine1=product.Address.AddressLine1,
                AddressLine2 = product.Address.AddressLine2,
                City = product.Address.City,
                State = product.Address.State,
                Country = product.Address.Country
            };
            var currentAddressId  = iAddressRepo.SaveAddress(addressModel); // address id of currently saving
            var currentAddress = iAddressRepo.GetAddressByID(currentAddressId); // get current address

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
            iProductRepo.SaveProduct(productModel); // new product save
            ViewBag.AddProductConfirmation = "Record added Succefully.";
            ModelState.Clear(); // clear form data in view
            return View();
        }

        /// <summary>
        /// Buy Now Button functionality change status of product in database
        /// </summary>
        /// <param name="ProductID"> product id </param>
        /// <param name="ProductStatus"> product status</param>
        /// <returns> return true</returns>
        public string BuyNowAction(int ProductID, bool ProductStatus) // action button mehod of offer notification 
        {
            string productStatus = "";
            if (ProductStatus == true)
            {

                ProductModel product = iProductRepo.GetProductById(ProductID); //get offer by id
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
                    ImagePath = product.ImagePath,
                    AddressId = product.AddressId,
                    AddedByUserId = product.AddedByUserId,
                    BidPrice = product.BidPrice,
                    ProductStatus = ProductStatus
                };

                iProductRepo.UpdateProduct(productModel);
                productStatus = "true";
            }
            return productStatus;
        }

    }
}