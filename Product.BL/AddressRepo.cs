using Product.Data;
using Product.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.BL
{
    public class AddressRepo
    {
        WITSProjectEntities objWITSProjectEntities; // database instance create
        public void SaveAddress(AddressModel addressModel) // save category
        {

            Product.Data.tblAddress address = new tblAddress()
            {
                AddressLine1 = addressModel.AddressLine1,
                AddressLine2 = addressModel.AddressLine2,
                City = addressModel.City,
                State = addressModel.State,
                Country = addressModel.Country
            };
                objWITSProjectEntities.tblAddress.Add(address);
                objWITSProjectEntities.SaveChanges();
        }
    }
}
    

