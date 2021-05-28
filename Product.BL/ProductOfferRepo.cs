using Product.IBL;
using Product.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.Data;

namespace Product.BL
{
    public class ProductOfferRepo : IProductOfferRepo
    {
        WITSProjectEntities objWITSProjectEntities; // database instance create
        public ProductOfferRepo() // ctor define
        {
            objWITSProjectEntities = new WITSProjectEntities();
        }

        public IEnumerable<ProductOfferModel> Getoffer()  // get all offers
        {
            List<tblOfferPrice> objTblOfferPrices = objWITSProjectEntities.tblOfferPrice.ToList();
            IEnumerable<ProductOfferModel> productOfferModel = objTblOfferPrices.Select(objProductOfferModel => new ProductOfferModel
            {
                OfferId = objProductOfferModel.OfferId,
                OfferPrice = (int)objProductOfferModel.OfferPrice,
                SenderId = objProductOfferModel.SenderId,
                ReceiverId = objProductOfferModel.ReceiverId,
                ProductId = objProductOfferModel.Product_Id
            });
            return productOfferModel;
        }

        public ProductOfferModel GetofferByID(int ID)  // get all offers
        {
            var objProductOfferModel = objWITSProjectEntities.tblOfferPrice.Where(p => p.Product_Id == ID).FirstOrDefault();
            ProductOfferModel productOfferModel = new ProductOfferModel()
            {
                OfferId = objProductOfferModel.OfferId,
                OfferPrice = (int)objProductOfferModel.OfferPrice,
                SenderId = objProductOfferModel.SenderId,
                ReceiverId = objProductOfferModel.ReceiverId,
                ProductId = objProductOfferModel.Product_Id
            };
           return productOfferModel;
        }

        public void SaveOffer(ProductOfferModel objProductOfferModel) // save offer data and returns int value
        {
            tblOfferPrice tblOffer = new tblOfferPrice()
            {
                OfferId = objProductOfferModel.OfferId,
                OfferPrice = objProductOfferModel.OfferPrice,
                SenderId = objProductOfferModel.SenderId,
                ReceiverId = objProductOfferModel.ReceiverId,
                Product_Id = objProductOfferModel.ProductId,
            };
            objWITSProjectEntities.tblOfferPrice.Add(tblOffer);
            objWITSProjectEntities.SaveChanges();
        }

    }
}
