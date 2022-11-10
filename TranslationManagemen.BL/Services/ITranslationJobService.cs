using External.ThirdParty.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using TranslationManagement.DAL.Entities;
using TranslationManagement.DAL.Enums;
using TranslationManagement.UnityOfWork;

namespace TranslationManagemen.BL.Services
{
    public interface ITranslationJobService
    {
        public List<TranslationJob> GetJobs();

        public Task<bool> CreateJob(TranslationJob job);

        public Task<bool> CreateJobWithFile(IFormFile file, string customer);

        public string UpdateJobStatus(int jobId, int translatorId, string newStatus = "");
    }
}
