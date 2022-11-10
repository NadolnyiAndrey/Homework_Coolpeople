using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TranslationManagement.DAL;
using TranslationManagement.DAL.Entities;
using TranslationManagement.Repositories;

namespace TranslationManagement.UnityOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _appDbContext;
        public ITranslationJobRepository _translationJobRepository;
        public ITranslatorModelRepository _translatorModelRepository;

        public UnitOfWork()
        {
            var contextOptions = new DbContextOptionsBuilder<AppDbContext>().UseSqlite("Data Source=TranslationAppDatabase.db").Options;

            _appDbContext = new AppDbContext(contextOptions);
        }
        public ITranslationJobRepository TranslationJobRepository
        {
            get { return _translationJobRepository = _translationJobRepository ?? new TranslationJobRepository(_appDbContext); }
        }
        public ITranslatorModelRepository TranslatorModelRepository
        {
            get { return _translatorModelRepository = _translatorModelRepository ?? new TranslatorModelRepository(_appDbContext); }
        }

        public List<TranslationJob> GetAllJobs()
        {
            return TranslationJobRepository.GetAll();
        }

        public TranslationJob GetJob(int id)
        {
            return TranslationJobRepository.Get(id);
        }

        public bool AddJob(TranslationJob entity)
        {
            return TranslationJobRepository.Add(entity);
        }

        public bool RemoveJob(int id)
        {
            return TranslationJobRepository.Remove(id);
        }

        public TranslationJob UpdateJob(TranslationJob entity)
        {
            return TranslationJobRepository.Update(entity);
        }

        public List<TranslatorModel> GetAllTranslators()
        {
            return TranslatorModelRepository.GetAll();
        }

        public TranslatorModel GetTranslator(int id)
        {
            return TranslatorModelRepository.Get(id);
        }

        public bool AddTranslator(TranslatorModel entity)
        {
            return TranslatorModelRepository.Add(entity);
        }

        public bool RemoveTranslator(int id)
        {
            return TranslatorModelRepository.Remove(id);
        }

        public TranslatorModel UpdateTranslator(TranslatorModel entity)
        {
            return TranslatorModelRepository.Update(entity);
        }

        public List<TranslatorModel> GetTranslatorsByName(string name)
        {
            return TranslatorModelRepository.GetTranslatorsByName(name);
        }
    }
}
