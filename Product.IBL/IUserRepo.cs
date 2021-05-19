using Product.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.IBL
{
    public interface IUserRepo // interface for User Class Model
    {

        //int Login(UserModel objUserModel); // for login the user
        //string cUser { get; set; }
        IEnumerable<UserModel> Login(UserModel objUserModel); // for login the user
        int SignUp(UserModel objUserModel); // for signup the user
        void Logout(); // for logut user
        UserModel GetUserById(int Id);
        IEnumerable<UserModel> GetUser();
       //string cUser{ get; set; }
    }
}
