using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proj400.Models;

namespace Proj400.Abstract
{
   public interface IProductsInfosRepository
    {
        IEnumerable<ProductInfo> ProductInfos { get; }
    }
}
