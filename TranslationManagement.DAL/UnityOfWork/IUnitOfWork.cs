using System.Collections.Generic;
using TranslationManagement.DAL.Entities;
using TranslationManagement.Repositories;

namespace TranslationManagement.UnityOfWork
{
    public interface IUnitOfWork
    {
        ITranslatorModelRepository TranslatorModelRepository { get; }
        ITranslationJobRepository TranslationJobRepository { get; }
        List<TranslationJob> GetAllJobs();
        TranslationJob GetJob(int id);
        bool AddJob(TranslationJob entity);
        bool RemoveJob(int id);
        TranslationJob UpdateJob(TranslationJob entity);
        List<TranslatorModel> GetAllTranslators();
        TranslatorModel GetTranslator(int id);
        bool AddTranslator(TranslatorModel entity);
        bool RemoveTranslator(int id);
        TranslatorModel UpdateTranslator(TranslatorModel entity);
        List<TranslatorModel> GetTranslatorsByName(string name);

    }
}
