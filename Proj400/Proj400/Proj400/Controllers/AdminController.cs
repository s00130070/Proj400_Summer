using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proj400.Abstract;
using System.Web.Mvc;
using Proj400.Models;

namespace Proj400.Controllers
{
    public class AdminController : Controller
    {

        private IProductsInfosRepository repository;
     
        // GET: Admin
        public AdminController(IProductsInfosRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index()
        {
            return View(repository.ProductInfos);
        }
        public ViewResult Edit(int product_Id)
        {
            ProductInfo product = repository.ProductInfos
            .FirstOrDefault(p => p.product_ID == product_Id);
            return View(product);
        }

        public ViewResult CreateProduct()
        {
            return View("Edit", new ProductInfo());
        }

        [HttpPost]
        public ActionResult Edit(ProductInfo productInfo, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    productInfo.Image_Mime_Type = image.ContentType;
                    productInfo.Image_Data = new byte[image.ContentLength];
                    image.InputStream.Read(productInfo.Image_Data, 0, image.ContentLength);
                }
                repository.updateProduct(productInfo);
                TempData["message"] = string.Format("{0} has been updated", productInfo.product_Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(productInfo);
            }
        }

        [HttpPost]
        public ActionResult Delete(int product_ID)
        {
            ProductInfo deleteProduct = repository.DeleteProduct(product_ID);
            if (deleteProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deleteProduct.product_Name);
            }
            return RedirectToAction("Index");
        }


    }
}