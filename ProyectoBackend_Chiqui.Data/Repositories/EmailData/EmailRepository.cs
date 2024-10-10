using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using ProyectoBackend_Chiqui.Model;
using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBackend_Chiqui.Data.Repositories.EmailData
{
    public class EmailRepository : IEmailRepository
    {
        private readonly EmailConfiguration _Email;
        public EmailRepository(EmailConfiguration email)
        {
            _Email = email;
        }
        public void SendEmail(EmailModel email)
        {
            // Configurar el correo electrónico
            var Email = new MimeMessage();
            Email.From.Add(MailboxAddress.Parse(_Email.User));  // Remitente
            Email.To.Add(MailboxAddress.Parse(email.To));       // Destinatario
            Email.Subject = email.Subject;                      // Asunto
            Email.Body = new TextPart(TextFormat.Html)          // Cuerpo en HTML
            {
                Text = email.Body
            };

            // Enviar el correo electrónico
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                smtp.Connect(_Email.Host, _Email.Port, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate(_Email.User, _Email.Pass);
                smtp.Send(Email);
            }
            finally
            {
                smtp.Disconnect(true);
            }
        }
    }
}
