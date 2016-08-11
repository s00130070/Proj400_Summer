using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proj400.Abstract;
using Proj400.Models;

namespace Proj400.Concrete
{
    public class EFProductRepository : IProductsInfosRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<ProductInfo> ProductInfos {
            get { return context.ProductInfos;}
        }

        public void updateProduct(ProductInfo productInfo)
        {
            if (productInfo.product_ID == 0)
            {
                context.ProductInfos.Add(productInfo);
            }
            else
            {
                ProductInfo dbEntry = context.ProductInfos.Find(productInfo.product_ID);
                if (dbEntry != null)
                {
                    dbEntry.product_Name = productInfo.product_Name;
                    dbEntry.product_Desc = productInfo.product_Desc;
                    dbEntry.product_Price = productInfo.product_Price;
                    dbEntry.product_Category = productInfo.product_Category;
                }
            }
            context.SaveChanges();
        }

        public ProductInfo DeleteProduct(int product_ID)
        {
            ProductInfo dbEntry = context.ProductInfos.Find(product_ID);
            if (dbEntry != null)
            {
                context.ProductInfos.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}