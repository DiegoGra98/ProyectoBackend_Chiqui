using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using ProyectoBackend_Chiqui.Model;
using ProyectoBackend_Chiqui.Model.Funciones;
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
        public void BienvenidaEmail(EmailModel email)
        {
            // Configurar el correo electrónico
            email.Subject = "Bienvenido (a)";
            var Email = new MimeMessage();
            Email.From.Add(MailboxAddress.Parse(_Email.User));  // Remitente
            Email.To.Add(MailboxAddress.Parse(email.To));       // Destinatario
            Email.Subject = email.Subject;                      // Asunto
                                                                // Leer el contenido del archivo HTML
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Construir la ruta relativa al archivo HTML
            string htmlFilePath = Path.Combine(baseDirectory, "TemplatesEmails", "CorreoBienvenida.html");
            string htmlBody = File.ReadAllText(htmlFilePath);

            Email.Body = new TextPart(TextFormat.Html)          // Cuerpo en HTML
            {
                Text = htmlBody
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

        public void RecContraseña(EmailModel email)
        {
            // Generar el código aleatorio
            GenerarCodigo generador = new GenerarCodigo();
            string codigo = generador.GenerarNumeroAleatorio(); // Código dinámico de 6 dígitos

            // Configurar el correo electrónico
            var Email = new MimeMessage();
            Email.From.Add(MailboxAddress.Parse(_Email.User));  // Remitente
            Email.To.Add(MailboxAddress.Parse(email.To));       // Destinatario
            Email.Subject = email.Subject;                      // Asunto
                                                                // Leer el contenido del archivo HTML
                                                                // Obtener el directorio base del proyecto
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Construir la ruta relativa al archivo HTML
            string htmlFilePath = Path.Combine(baseDirectory, "TemplatesEmails", "CorreoRecuperacion.html");
            string htmlBody = File.ReadAllText(htmlFilePath);

            // Reemplazar el marcador de posición {{codigo}} con el valor real del código generado
            htmlBody = htmlBody.Replace("{{codigo}}", codigo);

            Email.Body = new TextPart(TextFormat.Html)          // Cuerpo en HTML
            {
                Text = htmlBody
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
