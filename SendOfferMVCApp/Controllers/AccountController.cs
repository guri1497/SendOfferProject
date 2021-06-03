using Product.IBL;
using Product.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SendOfferMVCApp.Controllers
{
    [AllowAnonymous] // for authorize the controller work with global.asax
    public class AccountController : Controller // account contrller for login logout signup etc.
    {
        private IUserRepo iUserRepo; //instance of user interface for getting all methods etc.

        public AccountController(IUserRepo _iUserRepo) // define ctor
        {
            iUserRepo = _iUserRepo;
        }

        /// <summary>
        /// Login user into website
        /// </summary>
        /// <returns>login view</returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Post method of login method 
        /// </summary>
        /// <param name="userModel">form data recieced from end user</param>
        /// <returns>if success then redirect to index method of home controller and show all prodjuct
        /// if fail return same view
        /// </returns>
        [HttpPost]
        public ActionResult Login(UserModel userModel) 
        {
            IEnumerable<UserModel> cUser = iUserRepo.Login(userModel); // returns all user list
            var CurrentUser = cUser.Where(x => x.Email == userModel.Email && x.Password == userModel.Password).FirstOrDefault();// check user is login or not
            if (CurrentUser != null) // check condition
            {
                FormsAuthentication.SetAuthCookie(userModel.Name, false);
                Session["CurrentUserId"] = CurrentUser.Id;
                Session["CurrentUserName"] = CurrentUser.Name;
                return RedirectToAction("Index", "Home"); 
            }
            ModelState.AddModelError("", "Invalid User Name and Password "); 
            ViewBag.UserId = userModel.Id;
            return View();
        }

        /// <summary>
        /// Register new user in website
        /// </summary>
        /// <returns>signup form</returns>
        public ActionResult SignUp() // return sginup view
        {
            return View();
        }

        /// <summary>
        /// post method of signup mehtod save user record into database
        /// </summary>
        /// <param name="userModel">takes user data from end user in view</param>
        /// <returns>redirect to login for login customer into website</returns>
        [HttpPost]
        public ActionResult SignUp(UserModel userModel) 
        {
            if(ModelState.IsValid)
            {
                iUserRepo.SignUp(userModel);
                ViewBag.SignUpConfirmation = "Sign Up Succefully.";
                return RedirectToAction("Login");
            }
            ViewBag.SignUpConfirmation = "Enter valid data";
            return View();
        }

        /// <summary>
        /// signout user from website
        /// </summary>
        /// <returns> redirect to login page</returns>
        public ActionResult Logout() // signout the user
        {
            iUserRepo.Logout();
            return RedirectToAction("Login");
        }

    }
}