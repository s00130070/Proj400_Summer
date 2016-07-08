using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace Proj400.Binders
{
    public class CartBinder : IModelBinder
    {

        private const string sessionKey = "Cart";
        public bool BindModel(ModelBindingExecutionContext modelBindingExecutionContext, ModelBindingContext bindingContext)
        {
            throw new NotImplementedException();
        }
    }
}