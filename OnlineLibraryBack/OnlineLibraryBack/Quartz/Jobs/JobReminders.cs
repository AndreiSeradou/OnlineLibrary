using System;
using System.Threading.Tasks;
using OnlineLibraryPresentationLayer.Quartz.Jobs.Interface;
using Quartz;

namespace OnlineLibraryPresentationLayer.Quartz.Service
{
    public class JobReminders : IJob
    {
        private readonly IEmailSender _emailSender;

        public JobReminders(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("send");
            await _emailSender.SendEmail();
        }
    }
}
