using SalesUp.Entity;

namespace SalesUp.Data.Abstract;

public interface ISaleRepository : IGenericRepository<Sale>
{
    Task DeleteAllAsync(string userId);
}