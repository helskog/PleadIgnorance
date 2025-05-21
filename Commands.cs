using PleadIgnorance.Utils;
using VampireCommandFramework;

namespace PleadIgnorance;

public class Commands
{
	[Command("showmessageprompt", shortHand: "src", description: "Show the message prompt", adminOnly: true)]
	public void Test(ChatCommandContext ctx)
	{
		Chat.SendFormattedMessage(ctx.User);
	}
	
	[Command("accept", description: "test")]
	public void Accept(ChatCommandContext ctx)
	{
		Plugin.Instance!.AcceptedUsers.Add(ctx.User.PlatformId);
		ctx.Reply("You may now leave the spawn area!");
	}
}