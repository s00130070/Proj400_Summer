using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proj400.Abstract;
using System.Web.Mvc;

namespace Proj400.Controllers
{
    public class AdminController : Controller
    {

        private IProductsInfosRepository repository;
        // GET: Admin
        public ViewResult Index()
        {
            return View();
        }
    }
}