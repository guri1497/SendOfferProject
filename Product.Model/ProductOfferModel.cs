using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Model
{
    public class ProductOfferModel
    {
        public int OfferId { get; set; }
        public int OfferPrice { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int ProductId { get; set; }
        public string SenderName { get; set; }
        public string ProductName { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public virtual IEnumerable<UserModel> UserModels { get; set; }
        public virtual IEnumerable<ProductModel> ProductModels { get; set; }
    }
}
