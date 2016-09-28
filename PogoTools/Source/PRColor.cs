namespace PogoTools
{
	using UnityEngine;

	public class PRColor
	{
		public static string EncodeColor(Color c)
		{
			int i = 0xFFFFFF & (ColorToInt(c) >> 8);
			return DecimalToHex(i);
		}

		public static int ColorToInt(Color c)
		{
			int retVal = 0;
			retVal |= Mathf.RoundToInt(c.r * 255f) << 24;
			retVal |= Mathf.RoundToInt(c.g * 255f) << 16;
			retVal |= Mathf.RoundToInt(c.b * 255f) << 8;
			retVal |= Mathf.RoundToInt(c.a * 255f);
			return retVal;
		}

		public static string DecimalToHex(int num)
		{
			num &= 0xFFFFFF;
#if UNITY_FLASH
  StringBuilder sb = new StringBuilder();
  sb.Append(DecimalToHexChar((num >> 20) & 0xF));
  sb.Append(DecimalToHexChar((num >> 16) & 0xF));
  sb.Append(DecimalToHexChar((num >> 12) & 0xF));
  sb.Append(DecimalToHexChar((num >> 8) & 0xF));
  sb.Append(DecimalToHexChar((num >> 4) & 0xF));
  sb.Append(DecimalToHexChar(num & 0xF));
  return sb.ToString();
#else
			return num.ToString("X6");
#endif
		}
	}
}
