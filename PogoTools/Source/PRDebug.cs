namespace PogoTools
{
	using UnityEngine;
	using System.Text;

	public class PRDebug : PRSingleton<PRDebug>
	{

		private bool ColorEnable;
		private Color Color;
		private string ColorSharpStrBegin;
		private string ColorSharpStrEnd;

		public static void SetColorEnable(bool enable)
		{
			Instance.ColorEnable = enable;
		}

		public static string SetColor(Color color)
		{
			SetColorEnable(true);
			Instance.Color = color;
			string encode = PRColor.EncodeColor(color);
			Instance.mysb.Length = 0;
			Instance.mysb.Append("<color=#");
			Instance.mysb.Append(encode);
			Instance.mysb.Append(">");
			Instance.ColorSharpStrBegin = Instance.mysb.ToString();
			return Instance.ColorSharpStrBegin;
		}

		private StringBuilder mysb;

		public override void Initialize()
		{
			Instance.mysb = new StringBuilder();
			SetColor(Color.white);
			ColorSharpStrEnd = "</color>";
		}

		public static void TagLog(string tag, Color? color, object message)
		{
			if (!color.HasValue)
				SetColorEnable(false);

			else if (!Instance.ColorEnable || Instance.Color != color.Value)
				SetColor(color.Value);

			TagLog(tag, message);
		}

		public static void TagLog(string tag, object message)
		{
			Instance.mysb.Length = 0;
			if (Instance.ColorEnable) Instance.mysb.Append(Instance.ColorSharpStrBegin);
			Instance.mysb.Append("[");
			Instance.mysb.Append(tag);
			Instance.mysb.Append("]");
			if (Instance.ColorEnable) Instance.mysb.Append(Instance.ColorSharpStrEnd);
			Instance.mysb.Append(" ");
			Instance.mysb.Append(message.ToString());
			Debug.Log(Instance.mysb.ToString());
		}

		public static void Log(object message, Color? color)
		{
			if (!color.HasValue)
				SetColorEnable(false);

			else if (!Instance.ColorEnable || Instance.Color != color.Value)
				SetColor(color.Value);

			Log(message);
		}

		public static void Log(object message)
		{
			if (Instance.ColorEnable)
			{
				Instance.mysb.Length = 0;
				Instance.mysb.Append(Instance.ColorSharpStrBegin);
				Instance.mysb.Append(message.ToString());
				Instance.mysb.Append(Instance.ColorSharpStrEnd);
				Debug.Log(Instance.mysb.ToString());
			}
			else {
				Debug.Log(message);
			}
		}

		public static void LogFormat(string format, params object[] args)
		{
			if (Instance.ColorEnable)
			{
				Instance.mysb.Length = 0;
				Instance.mysb.Append(Instance.ColorSharpStrBegin);
				Instance.mysb.Append(format);
				Instance.mysb.Append(Instance.ColorSharpStrEnd);
				Debug.LogFormat(Instance.mysb.ToString(), args);
			}
			else {
				Debug.LogFormat(format, args);
			}
		}
	}
}