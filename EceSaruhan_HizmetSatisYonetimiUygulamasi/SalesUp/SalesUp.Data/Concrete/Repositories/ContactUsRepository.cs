using SalesUp.Data.Abstract;
using SalesUp.Data.Concrete.Contexts;

namespace SalesUp.Data.Concrete.Repositories
{
    public class ContactUsRepository : GenericRepository<Entity.ContactUs>, IContactUsRepository
    {
        public ContactUsRepository(SalesUpDbContext context) : base(context)
        {
        }

        private SalesUpDbContext? SalesUpDbContext => DbContext as SalesUpDbContext;

    }
}

