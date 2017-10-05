namespace EquipmentStore.Web.Infrastructure.EmailSenders
{
	public interface IEmailSender
	{
		void SendEmail(string sender, string recipient, string subject, string body);
	}
}