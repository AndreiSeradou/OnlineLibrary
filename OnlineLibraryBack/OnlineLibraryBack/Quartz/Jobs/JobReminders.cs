using System;
using System.Threading.Tasks;
using OnlineLibrary.BusinessLayer.Interfaces.Services;
using Quartz;

namespace OnlineLibrary.PresentationLayer.Quartz.Jobs
{
    public class JobReminders : IJob
    {
        private readonly IEmailSenderService _emailSenderService;

        public JobReminders(IEmailSenderService emailSenderService)
        {
            _emailSenderService = emailSenderService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _emailSenderService.SendEmail();
        }
    }
}
