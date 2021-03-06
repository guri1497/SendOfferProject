using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SendOfferMVCApp.Model
{
    public class NewProductAddressModel
    {
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Brand Name")]
        public string Brand { get; set; }
        [Required]
        [Display(Name = "Model No")]
        public string ModelNo { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string Category { get; set; }
        [Required]
        [Display(Name = "Condition")]
        public string Condition { get; set; }
        [Required]
        [Display(Name = "Buy Now Price")]
        public decimal BuyNowPrice { get; set; }
        [Required]
        [Display(Name = "Bid Price")]
        public decimal BidPrice { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Required]
        public int AddressId { get; set; }
        [Display(Name = "Remaining Time")]
        public String BidDateTime { get; set; }
        [Display(Name = "Image")]
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        [Required]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required]
        [Display(Name = "State")]
        public string State { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }
        public Nullable<int> AddedByUserId { get; set; }
        //public string AddedByUserName { get; set; }
        //public virtual IEnumerable<UserModel> UserModels { get; set; }
        //public virtual IEnumerable<ProductOfferModel> ProductOfferModels { get; set; }
        
    }
}