using Product.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web;
using Product.Data;

namespace Product.IBL
{
    public interface IProductRepo // interface for Product Model class
    {
        IEnumerable<ProductModel> GetAllProduct(); // define method for get all records of product class
        int AddProduct(ProductModel objProductModel); // define method for add record into database
        ProductModel GetProductById(int id);
        void SaveProduct(ProductModel objProductModel);
    }
}
