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
        public ViewResult Edit(int productId)
        {
            ProductInfo product = repository.ProductInfos
            .FirstOrDefault(p => p.product_ID == productId);
            return View(product);
        }



    }
}