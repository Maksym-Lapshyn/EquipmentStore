using EquipmentStore.Core.Loggers;
using EquipmentStore.Web.Infrastructure.EmailSenders;
using EquipmentStore.Web.Models;
using System;
using System.Web.Mvc;

namespace EquipmentStore.Web.Controllers
{
	public class HomeController : Controller
	{
		private const string ApplicationEmail = "lapshyn.maksym@gmail.com";
		private const string TempDataMessageKey = "Message";

		private readonly IEmailSender _emailSender;
		private readonly ILogger _logger;

		public HomeController(IEmailSender emailSender,
			ILogger logger)
		{
			_emailSender = emailSender;
			_logger = logger;
		}

		[HttpGet]
		[Route("")]
		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		[Route("contacts")]
		public ActionResult Contact()
		{
			var model = new FeedbackViewModel();

			return View(model);
		}

		[HttpPost]
		[Route("contacts")]
		public ActionResult Contact(FeedbackViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var message = ComposeEmail(model);
			var topic = $"Обратная связь - {model.FeedbackTopic.ToString()}";

			try
			{
				_emailSender.SendEmail(ApplicationEmail, model.Email, topic, message);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error sending email");

				TempData[TempDataMessageKey] = "Ошибка при отправлении письма";

				return View(model);
			}

			TempData[TempDataMessageKey] = "Ваше письмо отправлено";

			ModelState.Clear();

			return View(new FeedbackViewModel());
		}

		private string ComposeEmail(FeedbackViewModel model)
		{
			var message = $"<b>Сообщение от:</b> {model.Name}.<br />" +
						  "<br />" +
						  $"<b>Текст сообщения:</b> {model.Message}.";

			return message;
		}
	}
}