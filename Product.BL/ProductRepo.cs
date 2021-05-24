using Product.Data;
using Product.IBL;
using Product.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Product.BL
{
    public class ProductRepo : IProductRepo
    {
        WITSProjectEntities objWITSProjectEntities; // database instance create
        public ProductRepo() // ctor define
        {
            objWITSProjectEntities = new WITSProjectEntities();
        }

        public void SaveProduct(ProductModel objProductModel) // save category
        {
            Product.Data.tblProduct objProduct = new tblProduct() // database class instance
            {
                Name = objProductModel.Name, // assign model property to daatabase class
                Brand = objProductModel.Brand,
                ModelNo = objProductModel.ModelNo,
                Category = objProductModel.Category,
                Condition = objProductModel.Condition,
                BuyNowPrice = (int)objProductModel.BuyNowPrice,
                BidPrice = (int)objProductModel.BidPrice,
                Quantity = objProductModel.Quantity,
                AddressID = objProductModel.AddressId,
                BidEndDateTime = Convert.ToDateTime(objProductModel.BidDateTime),
                ImagePath = objProductModel.ImagePath,
                AddedByUserId = (int)objProductModel.AddedByUserId,
                //tblAddress = objProductModel.Address


            };
            objWITSProjectEntities.tblProduct.Add(objProduct); // add record into database
            objWITSProjectEntities.SaveChanges(); // save the record into table
        }

        public int AddProduct(ProductModel objProductModel) // add record into database
        {
            //var objProduct = new tblProduct();

            Product.Data.tblProduct objProduct = new tblProduct() // database class instance
            {
                Name = objProductModel.Name, // assign model property to daatabase class
                Brand = objProductModel.Brand,
                ModelNo = objProductModel.ModelNo,
                Category = objProductModel.Category,
                Condition = objProductModel.Condition,
                BuyNowPrice = (int)objProductModel.BuyNowPrice,
                BidPrice = (int)objProductModel.BidPrice,
                Quantity = objProductModel.Quantity,
                //AddressID = objProductModel.AddressId,
                BidEndDateTime = Convert.ToDateTime(objProductModel.BidDateTime),
                ImagePath = objProductModel.ImagePath,
                AddedByUserId = (int)objProductModel.AddedByUserId,
                //tblAddress = objProductModel.Address


            };
            objWITSProjectEntities.tblProduct.Add(objProduct); // add record into database
            return objWITSProjectEntities.SaveChanges(); // save the record into table
        }

        public IEnumerable<ProductModel> GetAllProduct() // get all records from database
        {
            List<tblProduct> allTblProducts = objWITSProjectEntities.tblProduct.ToList();
            IEnumerable<ProductModel> listOfProduct = allTblProducts.Select(objProductModel => new ProductModel
            {
                Id = objProductModel.ID,
                Name = objProductModel.Name,
                Brand = objProductModel.Brand,
                ModelNo = objProductModel.ModelNo,
                Category = objProductModel.Category,
                Condition = objProductModel.Condition,
                BuyNowPrice = (int)objProductModel.BuyNowPrice,
                BidPrice = (int)objProductModel.BidPrice,
                Quantity = objProductModel.Quantity,
                //AddressId = objProductModel.AddressID,
                BidDateTime = objProductModel.BidEndDateTime.ToString("yyy/MM/dd"),
                ImagePath = objProductModel.ImagePath,
                AddedByUserId = objProductModel.AddedByUserId,
            });
            return listOfProduct; // gives list of the products
        }

        public ProductModel GetProductById(int id) // get all records from database
        {
            tblProduct oneTblProducts = objWITSProjectEntities.tblProduct.Where(x => x.ID == id).FirstOrDefault();
            ProductModel listOfProduct = new ProductModel()
            {
                Id = oneTblProducts.ID,
                Name = oneTblProducts.Name,
                Brand = oneTblProducts.Brand,
                ModelNo = oneTblProducts.ModelNo,
                Category = oneTblProducts.Category,
                Condition = oneTblProducts.Condition,
                BuyNowPrice = (int)oneTblProducts.BuyNowPrice,
                BidPrice = (int)oneTblProducts.BidPrice,
                Quantity = oneTblProducts.Quantity,
                //AddressId = oneTblProducts.AddressID,
                BidDateTime = oneTblProducts.BidEndDateTime.ToString("yyy/MM/dd"),
                ImagePath = oneTblProducts.ImagePath,
                AddedByUserId = oneTblProducts.AddedByUserId,
            };
            return listOfProduct; // gives list of the products
        }

    }
}

































