using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Product.Data;

namespace Product.Model
{
    public class ProductModel // product model for product table in the datbase
    {
        //[Required]
        public int Id { get; set; } // define all propertys for get and set database data
        [Required]
        [Display(Name="Product Name")]
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
       // [Required]
        public int AddressId { get; set; }
        [Display(Name = "Remaining Time")]
        public String BidDateTime { get; set; }
        [Display(Name = "Image")]
        public string ImagePath { get; set; }
        public string ImageFile { get; set; }

        //public HttpPostedFileBase ImageFile { get; set; }
        //[Required]
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
        public virtual AddressModel Address { get; set; }


    }

    //public class Address // this is pending for getting all data from address table
    //{
    //    public int AddressID { get; set; }
    //    public string AddressLine1 { get; set; }
    //    public string AddressLine2 { get; set; }
    //    public string City{ get; set; }
    //    public string State { get; set; }
    //    public string Country{ get; set; }

    //}

}
