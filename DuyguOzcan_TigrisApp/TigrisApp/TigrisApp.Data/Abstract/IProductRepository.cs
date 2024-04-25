using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigrisApp.Entity.Concrete;

namespace TigrisApp.Data.Abstract
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        Task<List<Product>> GetAllProductsWithCategories();
    }
}