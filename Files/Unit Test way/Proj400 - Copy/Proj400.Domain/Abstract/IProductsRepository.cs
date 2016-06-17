using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proj400.Domain.Entities;

namespace Proj400.Domain.Abstract
{
   public interface IProductsInfosRepository
    {
        IEnumerable<ProductInfo> ProductInfos { get; }
    }
}
