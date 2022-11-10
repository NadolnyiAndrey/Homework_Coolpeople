using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslationManagement.DAL.Entities;
using TranslationManagement.DAL.Enums;
using TranslationManagement.UnityOfWork;

namespace TranslationManagemen.BL.Services
{
    public class TranslatorModelService : ITranslatorModelService
    {
        
        private IUnitOfWork _unitOfWork;

        public TranslatorModelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<TranslatorModel> GetTranslators()
        {
            return _unitOfWork.GetAllTranslators();
        }

        public List<TranslatorModel> GetTranslatorsByName(string name)
        {
            return _unitOfWork.GetTranslatorsByName(name);
        }

        public bool AddTranslator(TranslatorModel translator)
        {
            return _unitOfWork.AddTranslator(translator);
        }

        public string UpdateTranslatorStatus(int translatorId, string newStatus = "")
        {
            if (typeof(TranslatorStatuses).GetProperties().Count(prop => prop.Name == newStatus) == 0)
            {
                throw new ArgumentException("unknown status");
            }

            var translators = _unitOfWork.GetTranslator(translatorId);
            _unitOfWork.UpdateTranslator(translators);

            return "updated";
        }
    }
}
