using System.Collections.Generic;
using TranslationManagement.DAL.Entities;

namespace TranslationManagement.Repositories
{
    public interface ITranslatorModelRepository : IRepository<TranslatorModel>
    {
        List<TranslatorModel> GetTranslatorsByName(string name);
    }
}
