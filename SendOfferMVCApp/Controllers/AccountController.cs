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
        public ActionResult Login() // returns the login view first page loads
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel userModel) // handle the login form data and validate it and returns index view of home controller
        {
            IEnumerable<UserModel> cUser = iUserRepo.Login(userModel); // returns all user list
            var CurrentUser = cUser.Where(x => x.Email == userModel.Email && x.Password == userModel.Password).FirstOrDefault();// check user is login or not
            if (CurrentUser != null) // check condition
            {
                FormsAuthentication.SetAuthCookie(userModel.Name, false);
                Session["CurrentUserId"] = CurrentUser.Id;
                Session["CurrentUserName"] = CurrentUser.Name;
                return RedirectToAction("Index", "Home"); // if true return index view
            }
            ModelState.AddModelError("", "Invalid User Name and Password "); // if false return same view
            ViewBag.UserId = userModel.Id;
            return View();
        }

        //[HttpPost]
        //public ActionResult Login(UserModel userModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (WITSProjectEntities objWITSProjectEntities = new WITSProjectEntities())
        //        {
        //            var obj = db.UserProfiles.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
        //            if (obj != null)
        //            {
        //                Session["UserID"] = obj.UserId.ToString();
        //                Session["UserName"] = obj.UserName.ToString();
        //                return RedirectToAction("UserDashBoard");
        //            }
        //        }
        //    }
        //    return View(objUser);
        //}

        public ActionResult SignUp() // return sginup view
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserModel userModel) // check data from data and return login view
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

        public ActionResult Logout() // signout the user
        {
            iUserRepo.Logout();
            return RedirectToAction("Login");
        }

    }
}