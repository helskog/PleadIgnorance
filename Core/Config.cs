using BepInEx;
using BepInEx.Configuration;
#pragma warning disable CS8618

namespace PleadIgnorance.Core;

public static class Config
{
	internal static List<string> MessageLines;
	
	internal static ConfigEntry<string> Header;
	internal static ConfigEntry<string> Footer;
	
	internal static ConfigEntry<bool> PreventCaveExit;
	
	internal static void Initialize()
	{
		var configPath = Path.Combine(Paths.ConfigPath, "PleadIgnorance", "config.cfg");
		var messagePath = Path.Combine(Paths.ConfigPath, "PleadIgnorance", "message.cfg");
		
		if (!File.Exists(messagePath))
		{
			Directory.CreateDirectory(Path.GetDirectoryName(messagePath) ?? string.Empty);
			
			File.WriteAllText(messagePath,
				"<color=#ffffffff>Rule 1:</color> Dont be an asshole.\n" +
				"<color=#ffffffff>Rule 2:</color> <b>You can</b>\n" +
				"<color=#ffffffff>Rule 3:</color> <i>Also use</i>\n" +
				"<color=#ffffffff>Rule 4:</color> <size=10>Rich text</size>\n" +
				"<color=#ffffffff>Rule 5:</color> <size=15>Formatting in</size>\n" +
				"<color=#ffffffff>Rule 6:</color> <size=20>The <color=#add8e6ff>Message</color></size>"
			);
		}

		MessageLines = new List<string>(File.ReadAllLines(messagePath));
		
		Directory.CreateDirectory(Path.GetDirectoryName(configPath) ?? string.Empty);

		var cfg = new ConfigFile(configPath, saveOnInit: true);

		Header = cfg.Bind("Text", "Header", "<color=#add8e6ff>Server Rules</color>", "Message header text");
		Footer = cfg.Bind("Text", "Footer", "Type <color=#ffff00ff><b>.accept</b></color> to continue", "Message footer text");
		
		PreventCaveExit = cfg.Bind("Options", "PreventCaveExit", true, "Prevent cave exit until player accepts the rules.");
		
		Log.Info("Config Initialized");
	}
}