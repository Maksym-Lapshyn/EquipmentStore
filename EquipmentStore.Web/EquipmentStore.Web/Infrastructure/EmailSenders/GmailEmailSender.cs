using System.Web.Helpers;

namespace EquipmentStore.Web.Infrastructure.EmailSenders
{
	public class GmailEmailSender : IEmailSender
	{
		public const string UserName = "user@outlook.com";
		public const string Password = "password";

		public void SendEmail(string sender, string recipient, string subject, string body)
		{
			//Configuring webMail class to send emails  
			//gmail smtp server  
			WebMail.SmtpServer = "smtp.gmail.com";
			//gmail port to send emails  
			WebMail.SmtpPort = 587;
			WebMail.SmtpUseDefaultCredentials = true;
			//sending emails with secure protocol  
			WebMail.EnableSsl = true;
			//EmailId used to send emails from application  
			WebMail.UserName = "lapshyn.maksym@gmail.com";
			WebMail.Password = "egu3osyvidapy6";
			//Sender email address.  
			WebMail.From = sender;
			//Send email  
			WebMail.Send(recipient, subject, body);
		}
	}
}