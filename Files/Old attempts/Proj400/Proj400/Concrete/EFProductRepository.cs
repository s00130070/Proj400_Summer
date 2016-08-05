using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proj400.Abstract;
using Proj400.Models.Entities;

namespace Proj400.Concrete
{
    public class EFProductRepository : IProductsInfosRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<ProductInfo> ProductInfos {
            get { return context.ProductInfos;}
        }
    }
}