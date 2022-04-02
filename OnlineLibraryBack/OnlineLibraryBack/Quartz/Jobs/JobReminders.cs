using System;
using System.Threading.Tasks;
using BusinessLayer.Interfaces.Services;
using Quartz;

namespace OnlineLibraryPresentationLayer.Quartz.Service
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
            Console.WriteLine("send");
            await _emailSenderService.SendEmail();
        }
    }
}
