using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Admin;
using System;
using System.Collections.Generic;

namespace eUseControl.BusinessLogic
{
    public class ProductBL : AdminApi, IProduct
    {
        public ProdResp Insert(Product prod)
        {
            return InsertProduct(prod);
        }
        public List<Product> Get()
        {
            return GetProducts();
        }
        public Product GetSingle(int id)
        {
            return GetSingleByID(id);
        }

        public ProdResp Edit(Product product)
        {
            return EditAction(product);
        }

        public ProdResp DeleteProductById(int id)
        {
            return DeleteProductByIdAction(id);
        }
    }
}
