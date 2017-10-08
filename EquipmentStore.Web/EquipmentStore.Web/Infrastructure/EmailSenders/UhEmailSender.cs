using System.Net.Mail;

namespace EquipmentStore.Web.Infrastructure.EmailSenders
{
    public class UhEmailSender : IEmailSender
	{
		public const string UserName = "feedback@novfilpack.com.ua";
		public const string Password = "novfilpack";

		public void SendEmail(string sender, string recipient, string subject, string body)
		{
            using (var client = new SmtpClient("mail.novfilpack.com.ua", 587))
            {
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(UserName, Password);

                var mail = new MailMessage(UserName, recipient)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                client.Send(mail);
            };
        }
	}
}