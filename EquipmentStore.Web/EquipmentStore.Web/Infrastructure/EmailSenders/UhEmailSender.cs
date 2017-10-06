using System.Web.Helpers;

namespace EquipmentStore.Web.Infrastructure.EmailSenders
{
	public class UhEmailSender : IEmailSender
	{
		public const string UserName = "feedback@novfilpack.com.ua";
		public const string Password = "novfilpack";

		public void SendEmail(string sender, string recipient, string subject, string body)
		{
			//Configuring webMail class to send emails  
			//gmail smtp server  
			WebMail.SmtpServer = "mail.novfilpack.com.ua";
			//gmail port to send emails  
			WebMail.SmtpPort = 587;
			WebMail.SmtpUseDefaultCredentials = true;
			//sending emails with secure protocol  
			WebMail.EnableSsl = true;
			//EmailId used to send emails from application  
			WebMail.UserName = UserName;
			WebMail.Password = Password;
			//Sender email address.  
			WebMail.From = sender;
			//Send email  
			WebMail.Send(recipient, subject, body);
		}
	}
}