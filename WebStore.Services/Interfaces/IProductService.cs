using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebStore.Model.DataModels;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Interfaces
{
    public interface IProductService
    {
        ProductVm AddProduct(AddOrUpdateProductVm addOrUpdateProductVm);
        ProductVm GetProduct(Expression<Func<Product, bool>> filterExpression);
        IEnumerable<ProductVm> GetProducts(Expression<Func<Product, bool>>? filterExpression = null);
    }
}