using P013EStore.Core.Entities;
using System.Net;
using System.Net.Mail;

namespace P013EStore.WebAPIUsing.Utils
{
    public class MailHelper
    {
        public static async Task SendMailAsync(Contact contact, string konu = "Siteden Mesaj Geldi")
        {
            SmtpClient smtpClient = new("mail.siteadresi.com", 587);
            smtpClient.Credentials = new NetworkCredential("email kullanıcı adı", "email şifre");
            smtpClient.EnableSsl = false;
            MailMessage message = new();
            message.From = new MailAddress("info@siteadi.com");
            message.To.Add("info@siteadi.com");
            message.To.Add("test@siteadi.com");
            message.Subject = konu;
            message.Body = $"Mail Bilgileri : <hr/> Ad Soyad : {contact.Name} {contact.Surname} <hr/> Email : {contact.Email} <hr/> Telefon : {contact.Phone} <hr/> Mesaj : {contact.Message} <hr/> Mesaj Tarihi: {contact.CreateDate}";
            message.IsBodyHtml = true;
            //smtpClient.Send(message);
            await smtpClient.SendMailAsync(message);
            smtpClient.Dispose();
        }
    }
}