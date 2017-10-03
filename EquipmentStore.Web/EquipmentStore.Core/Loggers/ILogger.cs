using System;

namespace EquipmentStore.Core.Loggers
{
	public interface ILogger
	{
		void LogInfo(string message);

		void LogWarning(string message);

		void LogError(Exception exception, string message);

		void LogFatal(Exception exception, string message);
	}
}
