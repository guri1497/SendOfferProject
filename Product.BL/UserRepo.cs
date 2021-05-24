using Product.Data;
using Product.IBL;
using Product.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.SqlClient;

namespace Product.BL
{
    public class UserRepo : IUserRepo
    {
        WITSProjectEntities objWITSProjectEntities; // connection string instance for fetch all data

        public UserRepo() // construtor define
        {
            objWITSProjectEntities = new WITSProjectEntities();
        }

        public IEnumerable<UserModel> GetUser() // get all registerred users
        {
            List<User> objUser = objWITSProjectEntities.User.ToList();
            IEnumerable<UserModel> UserModel = objUser.Select(objUserModel => new UserModel
            {
                Id = objUserModel.Id,
                Name = objUserModel.UserName,
                Password = objUserModel.Password,
                Email = objUserModel.Email,
            });
            return UserModel;
        }

        public UserModel GetUserById(int userId) // get user by id
        {
            User user = objWITSProjectEntities.User.Where(x => x.Id == userId).FirstOrDefault();
            UserModel User = new UserModel()
            {
                Id = user.Id,
                Name = user.UserName,
                Password = user.Password,
                Email = user.Email
            };
            return User;
        }

        //string IUserRepo.cUser { get ; set ; }

        public IEnumerable<UserModel> Login(UserModel userModel) // check email and password in login form
        {
            //bool isValid = objWITSProjectEntities.Users.Any(x => x.Email == userModel.Email && x.Password == userModel.Password);
            //cUser = objWITSProjectEntities.Users.Where(x => x.Email == userModel.Email && x.Password == userModel.Password).FirstOrDefault().ToString();
            //User objUser = objWITSProjectEntities.Users.Where(x => x.Email == userModel.Email && x.Password == userModel.Password).FirstOrDefault();
            //return !isValid ? false : true;
            List<User> users = objWITSProjectEntities.User.ToList();
            IEnumerable<UserModel> cUser = users.Select(objUserModel => new UserModel 
            { 
                Id=objUserModel.Id,
                Name = objUserModel.UserName,
                Password = objUserModel.Password,
                Email = objUserModel.Email,
            });
            return cUser;

        }

        public void Logout() // signout user
        {
            FormsAuthentication.SignOut();
        }

        public int SignUp(UserModel userModel) // register new user in webstie
        {
            Product.Data.User objUser = new User() // product class object for fetch data
            {
                Id = userModel.Id, // assign model property to daatabase class
                UserName = userModel.Name,
                Password = userModel.Password,
                //ConfirmPassword = userModel.ConfirmPassword,
                Email = userModel.Email
            };


            objWITSProjectEntities.User.Add(objUser); //add new record into database
            return objWITSProjectEntities.SaveChanges(); // save record in database
        }
    }
}
