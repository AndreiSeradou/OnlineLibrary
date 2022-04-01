using System;
using System.Threading.Tasks;

namespace OnlineLibraryPresentationLayer.Quartz.Jobs.Interface
{
    public interface IEmailSender
    {
        public Task SendEmail();
    }
}
