using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proj400.Models;

namespace Proj400.Binders
{
    public class CartBinder : IModelBinder
    {
        private const string sessionKey = "Cart";
        public object BindModel(ControllerContext ControllerContext, ModelBindingContext bindingContext)
        {

            //ControllerContext provides access to all the information that the controller class has
            //ModelBindingContext gives you information about the model object you are being asked to build

            //getting the cart from the session
            Cart cart = null;
            if (ControllerContext.HttpContext.Session!= null)
            {
               cart= (Cart)ControllerContext.HttpContext.Session[sessionKey];
            }
            //create cart if doesnt already exsist in session data  
            if (cart== null)
            {     
                cart = new Cart();
                if (ControllerContext.HttpContext.Session != null)
                {
                    ControllerContext.HttpContext.Session[sessionKey] = cart;
                }
                
            }
            return cart;
        }
    }
}