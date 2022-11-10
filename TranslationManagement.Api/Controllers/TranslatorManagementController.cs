using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TranslationManagemen.BL.Services;
using TranslationManagement.DAL.Entities;
using TranslationManagement.DAL.Enums;
using TranslationManagement.UnityOfWork;

namespace TranslationManagement.Api.Controlers
{
    [ApiController]
    [Route("api/TranslatorsManagement/[action]")]
    public class TranslatorManagementController : ControllerBase
    {
        ITranslatorModelService _translatorModelService;
        private readonly ILogger<TranslatorManagementController> _logger;
        public TranslatorManagementController(ITranslatorModelService translatorModelService, ILogger<TranslatorManagementController> logger)
        {
            _translatorModelService = translatorModelService;
            _logger = logger;
        }

        [HttpGet]
        public List<TranslatorModel> GetTranslators()
        {
            return _translatorModelService.GetTranslators();
        }

        [HttpGet]
        public List<TranslatorModel> GetTranslatorsByName(string name)
        {
            return _translatorModelService.GetTranslatorsByName(name);
        }

        [HttpPost]
        public bool AddTranslator(TranslatorModel translator)
        {
            return _translatorModelService.AddTranslator(translator);
        }
        
        [HttpPost]
        public string UpdateTranslatorStatus(int translatorId, string newStatus = "")
        {
            _logger.LogInformation("User status update request: " + newStatus + " for user " + translatorId.ToString());
            return _translatorModelService.UpdateTranslatorStatus(translatorId, newStatus);
        }
    }
}