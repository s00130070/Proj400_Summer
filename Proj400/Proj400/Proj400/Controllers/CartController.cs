using Braintree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proj400.Models;
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


        //Braintree
        public IBraintreeConfiguration config = new BraintreeConfiguration();

        public static readonly TransactionStatus[] transactionSuccessStatuses = {
                                                                                    TransactionStatus.AUTHORIZED,
                                                                                    TransactionStatus.AUTHORIZING,
                                                                                    TransactionStatus.SETTLED,
                                                                                    TransactionStatus.SETTLING,
                                                                                    TransactionStatus.SETTLEMENT_CONFIRMED,
                                                                                    TransactionStatus.SETTLEMENT_PENDING,
                                                                                    TransactionStatus.SUBMITTED_FOR_SETTLEMENT
                                                                                };

        public ActionResult New()
        {
            var gateway = config.GetGateway();
            var clientToken = gateway.ClientToken.generate();
            ViewBag.ClientToken = clientToken;
            return View();
        }

        public ActionResult Create()
        {
            var gateway = config.GetGateway();
            Decimal amount;

            try
            {
                amount = Convert.ToDecimal(Request["amount"]);
            }
            catch (FormatException e)
            {
                TempData["Flash"] = "Error: 81503: Amount is an invalid format.";
                return RedirectToAction("New");
            }

            var nonce = Request["payment_method_nonce"];
            var request = new TransactionRequest
            {
                Amount = amount,
                PaymentMethodNonce = nonce
            };

            Result<Transaction> result = gateway.Transaction.Sale(request);
            if (result.IsSuccess())
            {
                Transaction transaction = result.Target;
                return RedirectToAction("Show", new { id = transaction.Id });
            }
            else if (result.Transaction != null)
            {
                return RedirectToAction("Show", new { id = result.Transaction.Id });
            }
            else
            {
                string errorMessages = "";
                foreach (ValidationError error in result.Errors.DeepAll())
                {
                    errorMessages += "Error: " + (int)error.Code + " - " + error.Message + "\n";
                }
                TempData["Flash"] = errorMessages;
                return RedirectToAction("New");
            }

        }

        public ActionResult Show(String id)
        {
            var gateway = config.GetGateway();
            Transaction transaction = gateway.Transaction.Find(id);

            if (transactionSuccessStatuses.Contains(transaction.Status))
            {
                TempData["header"] = "Transaction Success!";
                TempData["icon"] = "4";
               
            }
            else
            {
                TempData["header"] = "Transaction Failed";
                TempData["icon"] = "5";

            };

            ViewBag.Transaction = transaction;
            return View();
        }








    }
}