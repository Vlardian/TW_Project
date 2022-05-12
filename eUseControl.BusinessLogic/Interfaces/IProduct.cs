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
            ULoginResp CreateProduct(PDbTable product);
            ULoginResp EditProduct(PDbTable product);
            List<ProductData> GetProductList(int page);

            PDbTable GetSingleProduct(int id);

            ULoginResp DeleteProductById(int id);
    }
}
