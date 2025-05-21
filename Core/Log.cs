using BepInEx.Logging;

namespace PleadIgnorance.Core;

public static class Log
{
	private static ManualLogSource? LogSource { get; set; }

	public static void Initialize(ManualLogSource? logSource)
	{
		LogSource = logSource;

		LogSource?.LogInfo($"[Log] Source Initialized");
	}

	public static void Info(string message)
	{
		LogSource?.LogInfo($"{message}");
	}

	public static void Message(string message)
	{
		LogSource?.LogMessage($"{message}");
	}

	public static void Warning(string message)
	{
		LogSource?.LogWarning($"{message}");
	}

	public static void Error(string message)
	{
		LogSource?.LogError($"{message}");
	}
}
