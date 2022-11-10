
using TranslationManagement.DAL;
using TranslationManagement.DAL.Entities;

namespace TranslationManagement.Repositories
{
    public class TranslationJobRepository : Repository<TranslationJob>, ITranslationJobRepository
    {
        public TranslationJobRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
