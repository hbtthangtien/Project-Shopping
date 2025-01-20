using AutoMapper;
using Domain.Configs;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EmailService : BaseService, ISenderService
    {
        public readonly EmailConfig _emailConfig;
        public EmailService(IMapper mapper, IUnitOfWork unitOfWork, IOptions<EmailConfig> options)
            : base(mapper, unitOfWork)
        {
            _emailConfig = options.Value;
        }

        public async Task Send(string to, string subject, string body)
        {
            var smtpClient = new SmtpClient
            {
                Host = _emailConfig.Host,
                Port = int.Parse(_emailConfig.Port),
                Credentials = new System.Net.NetworkCredential(
                _emailConfig.Username, _emailConfig.Password),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailConfig.From),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mailMessage.To.Add(to);
            await smtpClient.SendMailAsync(mailMessage);

        }
    }
}
