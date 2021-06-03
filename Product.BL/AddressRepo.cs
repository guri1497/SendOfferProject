using Product.Data;
using Product.IBL;
using Product.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Product.BL
{
    public class AddressRepo : IAddressRepo
    {
        WITSProjectEntities objWITSProjectEntities; // database instance create\
        public AddressRepo() // ctor define
        {
            objWITSProjectEntities = new WITSProjectEntities();
        }

        public int SaveAddress(AddressModel addressModel) // save new address
        {
            tblAddress address = new tblAddress()
            {
                Id = addressModel.Id,
                AddressLine1 = addressModel.AddressLine1,
                AddressLine2 = addressModel.AddressLine2,
                City = addressModel.City,
                State = addressModel.State,
                Country = addressModel.Country
            };
            objWITSProjectEntities.tblAddress.Add(address);
            objWITSProjectEntities.SaveChanges();
            return address.Id;
        }

        public AddressModel GetAddressByID(int id) //get address by id
        {
            tblAddress tblAddress = objWITSProjectEntities.tblAddress.Find(id);

            return new AddressModel()
            {
                Id = tblAddress.Id,
                AddressLine1 = tblAddress.AddressLine1,
                AddressLine2 = tblAddress.AddressLine2,
                City = tblAddress.City,
                State = tblAddress.State,
                Country = tblAddress.Country
            };
        }
    }
}


