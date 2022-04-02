using System.Threading.Tasks;

namespace BusinessLayer.Interfaces.Services
{
    public interface IEmailSenderService
    {
        public Task SendEmail();
    }
}
