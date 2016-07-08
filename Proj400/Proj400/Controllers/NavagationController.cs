using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proj400.Abstract;


namespace Proj400.Controllers
{
    public class NavagationController : Controller
    {
        //nc

        private IProductsInfosRepository repository;

        public NavagationController(IProductsInfosRepository repo) {
            repository = repo;
        }
        public PartialViewResult Menu(string category = null) {

            ViewBag.SelectedCategory = category; //currently irrelevant  using display cat name

            IEnumerable<string> categories = repository.ProductInfos
                                             .Select(x => x.product_Category)
                                             .Distinct()
                                             .OrderBy(x => x);
            return PartialView(categories);
        }

    }
}