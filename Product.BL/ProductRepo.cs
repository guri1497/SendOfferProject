using Product.Data;
using Product.IBL;
using Product.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Product.Data;
using System.Data.Entity.Migrations;

namespace Product.BL
{
    public class ProductRepo : IProductRepo
    {
        WITSProjectEntities objWITSProjectEntities; // database instance create
        IAddressRepo iAddressRepo;
        public ProductRepo() // ctor define
        {
            objWITSProjectEntities = new WITSProjectEntities();
        }

        public void SaveProduct(ProductModel objProductModel) // save category
        {
            tblAddress objtblAddress = new tblAddress()
            {
                Id = objProductModel.Address.Id,
                AddressLine1 = objProductModel.Address.AddressLine1,
                AddressLine2 = objProductModel.Address.AddressLine2,
                City = objProductModel.Address.City,
                State = objProductModel.Address.State,
                Country = objProductModel.Address.Country
            };
           

            tblProduct objProduct = new tblProduct() // database class instance
            {
                ID = objProductModel.Id,
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
                tblAddress = objtblAddress
            };
            objWITSProjectEntities.tblProduct.Add(objProduct); // add record into database
            objWITSProjectEntities.SaveChanges(); // save the record into table
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
                AddressId = objProductModel.AddressID,
                BidDateTime = objProductModel.BidEndDateTime.ToString("yyy/MM/dd"),
                ImagePath = objProductModel.ImagePath,
                AddedByUserId = objProductModel.AddedByUserId,
                AddressLine1 = objProductModel.tblAddress.AddressLine1,
                AddressLine2 = objProductModel.tblAddress.AddressLine2,
                City = objProductModel.tblAddress.City,
                State = objProductModel.tblAddress.State,
                Country = objProductModel.tblAddress.Country
                
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
                AddressId = oneTblProducts.AddressID
                
            };
            return listOfProduct; // gives list of the products
        }

        public void UpdateProduct(ProductModel objProductModel) // save offer data and returns int value
        {
            //tblAddress objtblAddress = new tblAddress()
            //{
            //    Id = objProductModel.Address.Id,
            //    AddressLine1 = objProductModel.Address.AddressLine1,
            //    AddressLine2 = objProductModel.Address.AddressLine2,
            //    City = objProductModel.Address.City,
            //    State = objProductModel.Address.State,
            //    Country = objProductModel.Address.Country
            //};


            tblProduct objProduct = new tblProduct() // database class instance
            {
                ID = objProductModel.Id,
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
                //tblAddress = objtblAddress,
                ProductStatus = objProductModel.ProductStatus
            };

            //objWITSProjectEntities.Entry(tblOffer).State = EntityState.Unchanged;
            //objWITSProjectEntities.tblOfferPrice.Add(tblOffer);
            objWITSProjectEntities.Set<tblProduct>().AddOrUpdate(objProduct);

            objWITSProjectEntities.SaveChanges();
        }

    }
}

































