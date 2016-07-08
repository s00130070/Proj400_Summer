using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proj400.Models.Entities;
using Proj400.Abstract;

namespace Proj400.Controllers
{
    public class CartController : Controller
    {
        private IProductsInfosRepository repository;

        public CartController(IProductsInfosRepository repo) {
            repository = repo;
        }

        public ViewResult Index(Cart cart, string returnUrl) {
            return View(new CartIndex
            {
                ReturnUrl = returnUrl,
                Cart = cart
               
            });

        }

  
        public RedirectToRouteResult AddToCart(Cart cart, int product_Id, string returnUrl) {
            ProductInfo productInfo = repository.ProductInfos.FirstOrDefault(p => p.product_ID == product_Id);
            if (productInfo != null)
            {
                cart.AddItem(productInfo, 1);
            }
            return RedirectToAction("Index", new { returnUrl });

        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int product_ID, string returnUrl)
        {
            ProductInfo productInfo = repository.ProductInfos.FirstOrDefault(p => p.product_ID == product_ID);
            if (productInfo != null)
            {
                cart.RemoveRow(productInfo);
            }
            return RedirectToAction("Index", new { returnUrl });

        }

        public PartialViewResult CartNavSummary(Cart cart) {
            return PartialView(cart);
        }

        public ViewResult CheckoutShipping()
        {
            return View(new OrderInfo());
        }

        public ViewResult Payment()
        {
            return View("Payment");
        }
    }
}