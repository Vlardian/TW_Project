using eUseControl.BusinessLogic.DBModel.Seed;
using eUseControl.Domain.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.Core
{
    public class AdminApi
    {
        internal ProdResp InsertProduct(Product prod)
        {
            int result;
            using (var db = new UserContext())
            {
                db.Products.Add(prod);
                result = db.SaveChanges();
            }
            if (result == 0)
            {
                return new ProdResp
                {
                    Status = false,
                    StatusMsg = "Produsule nu s-a salvat."
                };
            }
            return new ProdResp { Status = true };
        }
        internal List<Product> GetProducts()
        {
            using (var db = new UserContext())
            {
                var result = db.Products.Select(x => x).ToList<Product>();
                return result;
            }
        }

        internal Product GetSingleByID(int id)
        {
            using (var db = new UserContext())
            {
                var result = db.Products.FirstOrDefault(p => p.Id == id);
                if (result != null) { return result; }
                else { return new Product(); }
            }
        }

        internal ProdResp EditAction(Product product)
        {
            using (var db = new UserContext())
            {
                var tableProduct = db.Products.FirstOrDefault(p => p.Id == product.Id);
                if (tableProduct == null)
                {
                    return new ProdResp { Status = false, StatusMsg = "no such item id" };
                }
                if (product.Name != null && product.Name != tableProduct.Name)
                {
                    tableProduct.Name = product.Name;
                }

                if (product.Description != null && product.Description != tableProduct.Description)
                {
                    tableProduct.Description = product.Description;
                }

                if (product.Price != null && product.Price != tableProduct.Price)
                {
                    tableProduct.Price = product.Price;
                }

                if (product.ImagePath != null && product.ImagePath != tableProduct.ImagePath)
                {
                    tableProduct.ImagePath = product.ImagePath;
                }

                if (product.Category != null && product.Category != tableProduct.Category)
                {
                    tableProduct.Category = product.Category;
                }


                db.Entry(tableProduct).State = EntityState.Modified;
                db.SaveChanges();
            }
            return new ProdResp
            {
                Status = true
            };
        }
        internal ProdResp DeleteProductByIdAction(int id)
        {
            using (var db = new UserContext())
            {
                var result = db.Products.FirstOrDefault(p => p.Id == id);
                if (result != null)
                {
                    db.Products.Remove(result);
                    db.SaveChanges();
                    return new ProdResp { Status = true, StatusMsg = "Product was deleted" };
                }
                else
                {
                    return new ProdResp { Status = false, StatusMsg = "Couldn't delete, no such id" };
                }
            }

        }
    }
}
