using System.Net;
using Onion.Web.Utilities.Contracts;
using System.Net.Mail;

namespace Onion.Web.Utilities.Implementations
{
    public class EmailSender : IEmailSender
    {
        public void Send(string to, string subject, string body)
        {
            MailMessage mail = new MailMessage();

            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("onionarchitecturemvc@gmail.com", "Onion Architecture");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            smtpServer.Port = 587;
            smtpServer.Credentials = new NetworkCredential("onionarchitecturemvc@gmail.com", "onion123456");
            smtpServer.EnableSsl = true;

            smtpServer.Send(mail);
        }
    }
}