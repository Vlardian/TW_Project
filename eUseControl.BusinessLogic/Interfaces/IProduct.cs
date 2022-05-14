using eUseControl.Domain.Entities.Admin;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface IProduct
    {
        ProdResp Insert(Product prod);
        List<Product> Get();
        Product GetSingle(int id);

        ProdResp Edit(Product product);

        ProdResp DeleteProductById(int id);
    }
}
