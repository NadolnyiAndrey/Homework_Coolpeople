using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TranslationManagemen.BL.Services;
using TranslationManagement.Api.Controlers;
using TranslationManagement.DAL.Entities;

namespace TranslationManagement.Api.Controllers
{
    [ApiController]
    [Route("api/jobs/[action]")]
    public class TranslationJobController : ControllerBase
    {

        private ITranslationJobService _translationJobService;
        private ILogger<TranslatorManagementController> _logger;
        public TranslationJobController(ITranslationJobService translationJobService, ILogger<TranslatorManagementController> logger)
        {
            _translationJobService = translationJobService;
            _logger = logger;
        }

        [HttpGet]
        public List<TranslationJob> GetJobs()
        {
            return _translationJobService.GetJobs();
        }

        [HttpPost]
        public async Task<bool> CreateJob(TranslationJob job)
        {
            var result =  await _translationJobService.CreateJob(job);
            if(result)
            {
                _logger.LogInformation("New job notification sent");
            }
            return result;
        }

        [HttpPost]
        public async Task<bool> CreateJobWithFile(IFormFile file, string customer)
        {
            return await _translationJobService.CreateJobWithFile(file, customer);
        }

        [HttpPost]
        public string UpdateJobStatus(int jobId, int translatorId, string newStatus = "")
        {
            _logger.LogInformation("Job status update request received: " + newStatus + " for job " + jobId.ToString() + " by translator " + translatorId);
            return _translationJobService.UpdateJobStatus(jobId, translatorId, newStatus);
        }
    }
}