
using Product.Data;
using Product.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.IBL
{
    public interface IAddressRepo
    {
        int SaveAddress(AddressModel addressModel);
        AddressModel GetAddressByID(int id);
    }
}
