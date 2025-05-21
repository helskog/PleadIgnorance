using BepInEx;
using HarmonyLib;
using BepInEx.Unity.IL2CPP;
using System.Reflection;

using VampireCommandFramework;
// ReSharper disable ClassNeverInstantiated.Global

namespace PleadIgnorance;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInDependency("gg.deca.VampireCommandFramework")]

public class Plugin : BasePlugin
{
	public readonly List<ulong> AcceptedUsers = new();

	private static Harmony? _harmony;
	internal static Plugin? Instance { get; private set; }
	
	public override void Load()
	{
		Instance = this;
		
		Core.Log.Initialize(Log);
		Core.Config.Initialize();
		
		_harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
		_harmony.PatchAll(Assembly.GetExecutingAssembly());
		
		CommandRegistry.RegisterAll();
		
		Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} version {MyPluginInfo.PLUGIN_VERSION} is loaded!");
	}

	public override bool Unload()
	{
		_harmony?.UnpatchSelf();
		return true;
	}
}
