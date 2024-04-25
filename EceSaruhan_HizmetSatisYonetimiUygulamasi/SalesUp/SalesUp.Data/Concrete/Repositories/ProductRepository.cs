using Microsoft.EntityFrameworkCore;
using SalesUp.Data.Abstract;
using SalesUp.Data.Concrete.Contexts;
using SalesUp.Entity;

namespace SalesUp.Data.Concrete.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(SalesUpDbContext context) : base(context)
    {
    }

    private SalesUpDbContext SalesUpDbContext
    {
        get{return DbContext as SalesUpDbContext;}
    }

}