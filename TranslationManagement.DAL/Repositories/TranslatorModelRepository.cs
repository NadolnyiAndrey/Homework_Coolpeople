using System.Collections.Generic;
using System.Linq;
using TranslationManagement.DAL;
using TranslationManagement.DAL.Entities;

namespace TranslationManagement.Repositories
{
    public class TranslatorModelRepository : Repository<TranslatorModel>, ITranslatorModelRepository
    {
        public TranslatorModelRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public List<TranslatorModel> GetTranslatorsByName(string name)
        {
            return _entities.Where(x => x.Name == name).ToList();
        }
    }
}
