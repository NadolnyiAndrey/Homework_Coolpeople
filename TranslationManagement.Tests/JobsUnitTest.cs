using Moq;
using System;
using System.Threading.Tasks;
using TranslationManagemen.BL.Services;
using TranslationManagement.DAL.Entities;
using TranslationManagement.UnityOfWork;
using Xunit;

namespace TranslationManagement.Tests
{
    public class JobsUnitTest
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        private readonly ITranslationJobService _translationJobService;
        public JobsUnitTest()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _translationJobService = new TranslationJobService(_mockUnitOfWork.Object);
        }
        [Fact]
        public void Test_Create_New_Job_Succesfull()
        {
            var job = new TranslationJob() { Id = 0, CustomerName = "Customer", Status = "New", OriginalContent = "Content of a job to translate", TranslatedContent = "" };
            TranslationJob result = new TranslationJob();

            _mockUnitOfWork.Setup(k => k.AddJob(It.IsAny<TranslationJob>())).Returns(true).Callback<TranslationJob>(k => result = k);

            _translationJobService.CreateJob(job);

            Assert.True(result.Price > 0);
        }

        [Fact]
        public void Test_Update_Job_Wrong_Status()
        {
            var job = new TranslationJob() { Id = 0, CustomerName = "Customer", Status = "New", OriginalContent = "Content of a job to translate", TranslatedContent = "" };
            TranslationJob updatedJob = new TranslationJob();

            _mockUnitOfWork.Setup(k => k.UpdateJob(It.IsAny<TranslationJob>())).Callback<TranslationJob>(k => updatedJob = k);

            var result = _translationJobService.UpdateJobStatus(0,0, "Old");

            Assert.Equal("invalid status", result);
        }
    }
}
