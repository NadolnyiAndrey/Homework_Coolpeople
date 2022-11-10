using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslationManagement.DAL.Entities;

namespace TranslationManagemen.BL.Services
{
    public interface ITranslatorModelService
    {
        public List<TranslatorModel> GetTranslators();

        public List<TranslatorModel> GetTranslatorsByName(string name);

        public bool AddTranslator(TranslatorModel translator);

        public string UpdateTranslatorStatus(int translatorId, string newStatus = "");
    }
}
