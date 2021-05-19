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
            List<tblOfferPrice> objTblOfferPrices = objWITSProjectEntities.tblOfferPrices.ToList();
            IEnumerable<ProductOfferModel> productOfferModel = objTblOfferPrices.Select(objProductOfferModel => new ProductOfferModel
            {
                OfferId = objProductOfferModel.OfferId,
                OfferPrice = (int)objProductOfferModel.OfferPrice,
                SenderId = objProductOfferModel.SenderId,
                ReceiverId = objProductOfferModel.ReceiverId,
                ProductId = objProductOfferModel.Product_Id,
                //SenderName = objProductOfferModel.SenderName,
                //ReceiverName = objProductOfferModel.ReceiverName,
                //ProductName = objProductOfferModel.ProductName
            });
            return productOfferModel;
        }

        public int SaveOfferPrice(ProductOfferModel objProductOfferModel) // save offer data and returns int value
        {
            tblOfferPrice tblOffer = new tblOfferPrice()
            {
                OfferId = objProductOfferModel.OfferId,
                OfferPrice = objProductOfferModel.OfferPrice,
                SenderId = objProductOfferModel.SenderId,
                ReceiverId = objProductOfferModel.ReceiverId,
                Product_Id = objProductOfferModel.ProductId,
                //SenderName = objProductOfferModel.SenderName,
                //ReceiverName = objProductOfferModel.ReceiverName,
                //ProductName = objProductOfferModel.ProductName
            };
            objWITSProjectEntities.tblOfferPrices.Add(tblOffer);
            return objWITSProjectEntities.SaveChanges();
            
            
        }
    }
}
