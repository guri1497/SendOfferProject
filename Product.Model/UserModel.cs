using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Model
{
    public class UserModel // this is for user database
    {
        [Required]
        public int Id { get; set; }  // define all property for get and set data from database
        [Required(ErrorMessage = "Please enter your name.")]

        [Display(Name = "User Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your password.")]

        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter confirm password.")]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Please enter valid email address.")]
        [Display(Name = "Email  ")]
        public string Email { get; set; }
        public virtual IEnumerable<ProductModel> ProductModels { get; set; }
        public virtual IEnumerable<ProductOfferModel> ProductOfferModels { get; set; }

    }
}
