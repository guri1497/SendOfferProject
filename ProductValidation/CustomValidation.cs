//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ProductValidation
//{
//    public class CustomValidation : ValidationAttribute // this is pending for custom validations
//    {
//        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
//        {
//            if(value!=null)
//            {
//                string message = value.ToString();
//                if(message=="password")
//                {
//                    return ValidationResult.Success;
//                }
//            }
//            ErrorMessage = ErrorMessage ?? validationContext.DisplayName + "Confirm password is not match with password.";
//            return new ValidationResult(ErrorMessage);
//        }
//    }
//}
