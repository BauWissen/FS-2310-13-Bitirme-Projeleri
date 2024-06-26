﻿using CosmeticShop.UI.EmailServices.Abstract;
using System.Net.Mail;
using System.Net;

namespace CosmeticShop.UI.EmailServices.Concrete
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly string _host;
        private readonly int _port;
        private readonly bool _enableSsl;
        private readonly string _userName;
        private readonly string _password;

        public SmtpEmailSender(string host, int port, bool enableSsl, string userName, string password)
        {
            _host = host;
            _port = port;
            _enableSsl = enableSsl;
            _userName = userName;
            _password = password;
        }

        public async Task SendEmailAsync(string emailTo, string subject, string htmlMessage)
        {
            var client = new SmtpClient(_host, _port)
            {
                Credentials = new NetworkCredential(_userName, _password),
                EnableSsl = _enableSsl
            };
            await client.SendMailAsync(new MailMessage(_userName, emailTo, subject, htmlMessage)
            {
                IsBodyHtml = true
            });
        }
    }
}
