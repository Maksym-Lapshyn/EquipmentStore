using NLog;
using System;

namespace EquipmentStore.Core.Loggers
{
	public class NLogLogger : ILogger
	{
		private readonly NLog.ILogger _logger;

		public NLogLogger()
		{
			_logger = LogManager.GetCurrentClassLogger();
		}

		public void LogInfo(string message)
		{
			_logger.Info(message);
		}

		public void LogWarning(string message)
		{
			_logger.Warn(message);
		}

		public void LogError(Exception exception, string message)
		{
			_logger.Error(exception, message);
		}

		public void LogFatal(Exception exception, string message)
		{
			_logger.Fatal(exception, message);
		}
	}
}
