using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendOfferMVCApp.Model
{
    public class ShowOfferModel
    {
        public int ID { get; set; }
        public int ProductId { get; set; }
        public int OfferPrice { get; set; }
        public string Message { get; set; }
        public int SenderID { get; set; }
        public int RecieverID { get; set; }
        public string SenderName{ get; set; }
        public string ProductName { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> Counter { get; set; }


    }
}