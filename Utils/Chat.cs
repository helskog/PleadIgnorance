using System.Text;
using PleadIgnorance.Core;
using ProjectM;
using ProjectM.Network;
using Unity.Collections;

namespace PleadIgnorance.Utils;

public static class Chat
{
	public static void SendFormattedMessage(User target)
	{
		const int maxBytes = 512;
		var sb = new StringBuilder();
		var utf8 = Encoding.UTF8;

		int flushCount = 0;

		void Flush()
		{
			if (sb.Length == 0) return;

			string chunk = sb.ToString();
			if (utf8.GetByteCount(chunk) > maxBytes)
			{
				// Failsafe: truncate to maxBytes
				chunk = TruncateToByteLimit(chunk, maxBytes, utf8);
			}

			var msg = new FixedString512Bytes(chunk);
			ServerChatUtils.SendSystemMessageToClient(VWorld.EntityManager, target, ref msg);
			sb.Clear();
			flushCount++;
		}

		int Accumulate(string line)
		{
			int lineBytes = utf8.GetByteCount(line + "\n");

			if (utf8.GetByteCount(sb.ToString()) + lineBytes > maxBytes)
			{
				Flush();
				
				if (flushCount > 0)
				{
					sb.AppendLine();
				}
			}

			sb.AppendLine(line);
			return lineBytes;
		}
		
		if (!string.IsNullOrWhiteSpace(Config.Header?.Value))
		{
			Accumulate(Config.Header.Value);
		}
		
		foreach (var line in Config.MessageLines)
		{
			Accumulate(line);
		}
		
		if (!string.IsNullOrWhiteSpace(Config.Footer?.Value))
		{
			Accumulate(Config.Footer.Value);
		}

		Flush();
	}

	private static string TruncateToByteLimit(string input, int byteLimit, Encoding encoding)
	{
		int bytes = 0;
		var sb = new StringBuilder();
		foreach (char c in input)
		{
			int charBytes = encoding.GetByteCount(new[] { c });
			if (bytes + charBytes > byteLimit)
				break;

			sb.Append(c);
			bytes += charBytes;
		}

		return sb.ToString();
	}
}