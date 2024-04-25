using SalesUp.Entity;

namespace SalesUp.Data.Abstract;

public interface ISTaskRepository : IGenericRepository<STask>
{
    Task DeleteAllAsync(string userId);
}