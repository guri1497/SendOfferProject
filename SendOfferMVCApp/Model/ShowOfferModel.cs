using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendOfferMVCApp.Model
{
    public class ShowOfferModel
    {
        public int Id { get; set; }
        public string SenderName { get; set; }
        public string ProductName { get; set; }
        public int OfferPrice { get; set; }
    }
}