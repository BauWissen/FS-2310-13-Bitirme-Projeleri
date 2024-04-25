using SalesUp.Data.Abstract;
using SalesUp.Data.Concrete.Contexts;
using SalesUp.Entity;

namespace SalesUp.Data.Concrete.Repositories;

public class SubscriptionRepository : GenericRepository<Subscription>, ISubscriptionRepository
{
    public SubscriptionRepository(SalesUpDbContext context) : base(context)
    {
    }

    private SalesUpDbContext? SalesUpDbContext => DbContext as SalesUpDbContext;
}