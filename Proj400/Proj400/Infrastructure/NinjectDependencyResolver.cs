using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using Proj400.Abstract;
using Proj400.Models.Entities;
using Proj400.Concrete;

namespace Proj400.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            // put bindings here
            kernel.Bind<IProductsInfosRepository>().To<EFProductRepository>();

            //Fake Database
            //Mock<IProductsInfosRepository> mock = new Mock<IProductsInfosRepository>();
            //mock.Setup(m=>m.ProductInfos).Returns(new List<ProductInfo>(){
            //    new ProductInfo { product_Name = "Surf Board", product_Price=200},
            //    new ProductInfo { product_Name = "Surf Board 101", product_Price = 202 },
            //    new ProductInfo { product_Name = "Surf Board 202", product_Price = 203 } });

            //    kernel.Bind<IProductsInfosRepository>().ToConstant(mock.Object);
            }
        }

    }


