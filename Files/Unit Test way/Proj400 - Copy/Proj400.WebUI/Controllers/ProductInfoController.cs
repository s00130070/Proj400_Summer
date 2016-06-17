using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proj400.Domain.Abstract;
using Proj400.Domain.Entities;

namespace Proj400.WebUI.Controllers
{
    public class ProductInfoController : Controller
    {
        private IProductsInfosRepository repo;
        // GET: ProductInfo
        public ProductInfoController(IProductsInfosRepository productRepository)
        {
            this.repo = productRepository;
        }
        public ViewResult List(){
            return View(repo.ProductInfos);

        }

        public ViewResult Home() {

            return View("Home");
        }

        public ViewResult Cart()
        {

            return View("Cart");
        }

    }
}