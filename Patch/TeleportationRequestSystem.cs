using HarmonyLib;
using PleadIgnorance.Core;
using PleadIgnorance.Utils;
using ProjectM;
using ProjectM.Network;
using Unity.Collections;

namespace PleadIgnorance.Patch;

[HarmonyPatch(typeof(TeleportationRequestSystem), nameof(TeleportationRequestSystem.OnUpdate))]
public static class HandleTeleportationRequest
{
	private static void Prefix(TeleportationRequestSystem __instance)
	{
		var em = __instance.EntityManager;
		var query = __instance._TeleportRequestQuery;
		var requests = query.ToEntityArray(Allocator.Temp);
		
		foreach (var req in requests)
		{
			var teleportRequest = req.Read<TeleportationRequest>();
			var travelBuffPrefab = teleportRequest.CustomTravelBuffPrefab._Value;
			var playerEntity = teleportRequest.PlayerEntity;
			var playerChar = playerEntity.Read<PlayerCharacter>();
			var userEntity = playerChar.UserEntity;
			var userObj = userEntity.Read<User>();
			
			if (travelBuffPrefab == 2033937156 && !Plugin.Instance!.AcceptedUsers.Contains(userObj.PlatformId))
			{
				if (Config.PreventCaveExit.Value.Equals(true))
					em.DestroyEntity(req);
				
				Chat.SendFormattedMessage(userObj);
			}
		}

		requests.Dispose();
	}
}