using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proj400.Abstract;
using Proj400.Models.Entities;

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
        public ViewResult List(int page = 1){
            ProductsList productsList = new ProductsList {

             ProductInfo = repo.ProductInfos
            .OrderBy(p => p.product_ID)
            .Skip((page -1)* PageSize)
            .Take(PageSize),
            PagingInfo = new PagingInfo {
                CurrentPage = page,
                ItemsPerPage= PageSize,
                TotalItems =repo.ProductInfos.Count()
            }
            };
            return View(productsList);
            //return View(repo.ProductInfos.OrderBy(p => p.product_ID)
            //    .Skip((page - 1) * PageSize).Take(PageSize));
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