using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Proj400.Models.Entities;

namespace Proj400
{
    public class EFDbContext :DbContext
    {
        public DbSet<ProductInfo> ProductInfos { get; set; }
    }
}