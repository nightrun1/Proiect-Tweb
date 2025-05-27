using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenPC.BusinessLogic.Core;
using NextGenPC.BusinessLogic.Interfaces;
using NextGenPC.Domain.Entities.Product;
using NextGenPC.Domain.Entities.Product.ProductActionResponse;
using NextGenPC.Domain.Entities.User;

namespace NextGenPC.BusinessLogic.BLStruct
{
    public class AdminBL : IAdmin, IProduct
    {
        private readonly ProductAPI productAPI;
        private readonly AdminAPI adminAPI;

        public ProductResp AddProductLogic(ProdDataEntities product)
        {
            return productAPI.AddProduct(product);
        }

        public ProductResp DeleteProductLogic(int id)
        {
            return productAPI.DeleteProduct(id);
        }

        public bool DeleteUserLogic(int id)
        {
            return adminAPI.DeleteUser(id);
        }

        public List<ProdDataEntities> GetAllProductsLogic()
        {
            return productAPI.GetProducts();
        }

        public List<UserDataEntities> GetAllUsersLogic()
        {
            return adminAPI.GetAllUsers();
        }

        public ProdDataEntities GetProductByIdLogic(int id)
        {
            return productAPI.GetProductById(id);
        }

        public List<ProdDataEntities> SearchProductsLogic(string searchTerm)
        {
            return productAPI.SearchProducts(searchTerm);
        }

        public ProductResp UpdateProductLogic(ProdDataEntities product)
        {
            return productAPI.UpdateProduct(product);
        }

        public bool UpdateUserLogic(UserDataEntities user)
        {
            return adminAPI.UpdateUser(user);
        }
    }
}
