using System;
using System.Net.Mail;
using System.Threading.Tasks;
using BusinessLayer.Interfaces.Services;
using Configuration.GeneralConfiguration;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public EmailSenderService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task SendEmail()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApiDbContext>();

                var orders = await dbContext.Orders.Include(x => x.Book).Include(u => u.User)
                .AsNoTracking()
                .ToListAsync();

                foreach (var order in orders)
                {
                    if (order.DateTimeCreated.Month != DateTime.UtcNow.Month && order.Condition == true)
                    {
                        SmtpClient client = new SmtpClient(GeneralConfiguration.MailSmtp, 25);

                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new System.Net.NetworkCredential(GeneralConfiguration.QuartzEmail, GeneralConfiguration.QuartzPassword);
                        client.EnableSsl = true;

                        var mail = new MailMessage(GeneralConfiguration.QuartzEmail, order.User.Email);

                        mail.Subject = GeneralConfiguration.MailSubject;
                        mail.Body = $"Hello, {order.User.UserName}, book {order.Book.Name} expired, please come back the book.";
                        mail.IsBodyHtml = true;

                        await client.SendMailAsync(mail);
                    }
                }
            }
        }
    }
}
