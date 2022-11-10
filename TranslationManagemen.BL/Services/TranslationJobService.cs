using External.ThirdParty.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using TranslationManagement.DAL.Entities;
using TranslationManagement.DAL.Enums;
using TranslationManagement.UnityOfWork;

namespace TranslationManagemen.BL.Services
{
    public class TranslationJobService : ITranslationJobService
    {
        public IUnitOfWork _unitOfWork;
        public TranslationJobService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<TranslationJob> GetJobs()
        {
            return _unitOfWork.GetAllJobs();
        }

        const double PricePerCharacter = 0.01;
        private void SetPrice(TranslationJob job)
        {
            job.Price = job.OriginalContent.Length * PricePerCharacter;
        }

        public async Task<bool> CreateJob(TranslationJob job)
        {
            job.Status = "New";
            SetPrice(job);
            
            bool success = _unitOfWork.AddJob(job);
            if (success)
            {
                var notificationSvc = new UnreliableNotificationService();

                await notificationSvc.SendNotification("Job created: " + job.Id);
            }

            return success;
        }

        public async Task<bool> CreateJobWithFile(IFormFile file, string customer)
        {
            var reader = new StreamReader(file.OpenReadStream());
            string content;

            if (file.FileName.EndsWith(".txt"))
            {
                content = reader.ReadToEnd();
            }
            else if (file.FileName.EndsWith(".xml"))
            {
                var xdoc = XDocument.Parse(reader.ReadToEnd());
                content = xdoc.Root.Element("Content").Value;
                customer = xdoc.Root.Element("Customer").Value.Trim();
            }
            else
            {
                throw new NotSupportedException("unsupported file");
            }

            var newJob = new TranslationJob()
            {
                OriginalContent = content,
                TranslatedContent = "",
                CustomerName = customer,
            };

            SetPrice(newJob);

            return await CreateJob(newJob);
        }

        public string UpdateJobStatus(int jobId, int translatorId, string newStatus = "")
        {
            if (typeof(JobStatuses).GetProperties().Count(prop => prop.Name == newStatus) == 0)
            {
                return "invalid status";
            }

            var job = _unitOfWork.GetJob(jobId);

            bool isInvalidStatusChange = (job.Status == JobStatuses.New && newStatus == JobStatuses.Completed) ||
                                         job.Status == JobStatuses.Completed || newStatus == JobStatuses.New;
            if (isInvalidStatusChange)
            {
                return "invalid status change";
            }

            job.Status = newStatus;

            _unitOfWork.UpdateJob(job);
            return "updated";
        }
    }
}
