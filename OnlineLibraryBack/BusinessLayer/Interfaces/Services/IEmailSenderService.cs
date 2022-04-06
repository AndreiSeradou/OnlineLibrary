using System.Threading.Tasks;

namespace OnlineLibrary.BusinessLayer.Interfaces.Services
{
    public interface IEmailSenderService
    {
        public Task SendEmail();
    }
}
