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

        public ViewResult Index(string returnUrl) {
            return View(new CartIndex
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });

        }

        private Cart GetCart() {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public RedirectToRouteResult AddToCart(int product_Id, string returnUrl) {
            ProductInfo productInfo = repository.ProductInfos.FirstOrDefault(p => p.product_ID == product_Id);
            if (productInfo != null)
            {
                GetCart().AddItem(productInfo, 1);
            }
            return RedirectToAction("Index", new { returnUrl });

        }
        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            ProductInfo productInfo = repository.ProductInfos.FirstOrDefault(p => p.product_ID == productId);
            if (productInfo != null)
            {
                GetCart().RemoveRow(productInfo);
            }
            return RedirectToAction("Index", new { returnUrl });

        }

    }
}