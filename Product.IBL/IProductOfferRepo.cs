using Product.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.IBL
{
    public interface IProductOfferRepo
    {
        //int SaveOfferPrice(ProductOfferModel objProductOfferModel);
        IEnumerable<ProductOfferModel> Getoffer();
        void SaveOffer(ProductOfferModel objProductOfferModel);
        void UpdateOffer(ProductOfferModel objProductOfferModel);
        ProductOfferModel GetofferByID(int ID);
    }
}
