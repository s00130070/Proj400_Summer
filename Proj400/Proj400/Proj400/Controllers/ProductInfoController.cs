using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proj400.Abstract;
using Proj400.Models;

namespace Proj400.Controllers
{
    public class ProductInfoController : Controller
    {
        private IProductsInfosRepository repo;
        public int PageSize = 3;
        // GET: ProductInfo
        public ProductInfoController(IProductsInfosRepository productRepository)
        {
            this.repo = productRepository;
        }
        //public ViewResult List()
        //{
        //    return View(repo.ProductInfos);
        //}

        public ViewResult List(string category, int page = 1)
        {
            ProductsList productsList = new ProductsList
            {

                ProductInfo = repo.ProductInfos
             .Where(p => category == null || p.product_Category == category)
            .OrderBy(p => p.product_ID)
            .Skip((page - 1) * PageSize)
            .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    //TotalItems =repo.ProductInfos.Count() counts everything in database issue was wouldnt work correctly when was filtered by catagory would still enable pagnation for products not in cat
                    TotalItems = category == null ? repo.ProductInfos.Count() : repo.ProductInfos.Where(e => e.product_Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(productsList);
        }
        [RequireHttps]
        public ViewResult Home() {

            return View("Home");
        }

        public ViewResult Cart()
        {

            return View("Cart");
        }

    }
}