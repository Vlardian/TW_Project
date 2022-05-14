using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Admin;
using eUseControl.Web.App_Start;
using eUseControl.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _product;
        public ProductController()
        {
            var bl = new BussinesLogic();
            _product = bl.getProductBL();
        }
        // GET: Product
        public ActionResult Index()
        {
            var products = _product.Get();

            List<MProduct> productsList = new List<MProduct>();

            foreach (var product in products)
            {
                productsList.Add(new MProduct
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = (float)product.Price,
                    Category = product.Category,
                    Description = product.Description,
                    ImagePath = product.ImagePath
                });
            }

            return View(productsList);
        }
        public ActionResult Display(int id)
        {
            var product = _product.GetSingle(id);
            return View(new MProduct
            {
                Id = product.Id,
                Name = product.Name,
                Price = (float)product.Price,
                Category = product.Category,
                Description = product.Description,
                ImagePath = product.ImagePath
            });
        }

        [ModeratorMod]
        public ActionResult Create()
        {

            return View();
        }

        [ModeratorMod]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MProduct product, HttpPostedFileBase file)
        {
            string fileName;
            if (file != null)
            {
                FileInfo fi = new FileInfo(file.FileName);

                using (var md5 = MD5.Create())
                {
                    fileName = BitConverter.ToString(md5.ComputeHash(file.InputStream)).Replace("-", "");
                    product.ImagePath = "~/Content/Img/" + fileName + fi.Extension;

                    file.SaveAs(Path.Combine(Server.MapPath("~/Content/Img/"), fileName + fi.Extension));
                }

            }

            var createStatus = _product.Insert(new Product
            {
                Name = product.Name,
                Price = (decimal)product.Price,
                Category = product.Category,
                Description = product.Description,
                ImagePath = product.ImagePath
            });

            if (createStatus.Status)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", createStatus.StatusMsg);
                return View("Create");
            }

        }

        public ActionResult Edit(int id)
        {
            var product = _product.GetSingle(id);

            return View(new MProduct
            {
                Name = product.Name,
                Price = (float)product.Price,
                Category = product.Category,
                Description = product.Description,
                ImagePath = product.ImagePath
            });

        }

        [ModeratorMod]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MProduct product, HttpPostedFileBase file)
        {
            string fileName;
            if (file != null)
            {
                FileInfo fi = new FileInfo(file.FileName);

                using (var md5 = MD5.Create())
                {
                    fileName = BitConverter.ToString(md5.ComputeHash(file.InputStream)).Replace("-", "");
                    product.ImagePath = "~/Content/Img/" + fileName + fi.Extension;

                    file.SaveAs(Path.Combine(Server.MapPath("~/Content/Img/"), fileName + fi.Extension));
                }

            }

            var createStatus = _product.Edit(new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = (decimal)product.Price,
                Category = product.Category,
                Description = product.Description,
                ImagePath = product.ImagePath
            });

            if (createStatus.Status)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", createStatus.StatusMsg);
                return View("Edit");
            }

        }



        [ModeratorMod]
        public string Delete(int id)
        {
            var response = _product.DeleteProductById(id);
            return response.StatusMsg;
        }
    }
}