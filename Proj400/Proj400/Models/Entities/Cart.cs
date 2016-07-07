using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proj400.Models.Entities
{
    public class Cart
    {
        //The Cart class uses the Cart row class to represent product and quantity the user wants to buy.
        private List<CartRow> rowCollection = new List<CartRow>();

        public void  AddItem(ProductInfo product, int quantity) {
            CartRow row = rowCollection
                .Where(p => p.Product.product_ID == product.product_ID)
                .FirstOrDefault();

            if (row == null)
            {
                rowCollection.Add(new CartRow { Product = product, Quantity = quantity });
            }
            else
            {
                row.Quantity += quantity;

            }
        }

        public void RemoveRow(ProductInfo product) {
            rowCollection.RemoveAll(l => l.Product.product_ID == product.product_ID);

        }

        public decimal ComputeToatalValue() {
            return rowCollection.Sum(e => e.Product.product_Price * e.Product.product_Quantity);
        }
        public void Clear() {
            rowCollection.Clear();

        }

        public IEnumerable<CartRow> Rows {
            get{ return rowCollection; }
        }

    }

}