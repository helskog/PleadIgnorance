using Unity.Entities;

namespace PleadIgnorance.Core;

internal static class Extensions
{
	private static EntityManager Em => VWorld.EntityManager;
		
	public static unsafe T Read<T>(this Entity entity) where T : struct
	{
		return Em.GetComponentData<T>(entity);
	}
	
	public static void ExploreEntity(this Entity entity)
	{
		var sb = new Il2CppSystem.Text.StringBuilder();
		ProjectM.EntityDebuggingUtility.DumpEntity(VWorld.Server, entity, true, sb);
		Log.Info(sb.ToString());
	}
}