using System;
using UnityEngine;
using PogoTools;

namespace PogoTools.Test
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Color color = Color.red;
			Console.WriteLine(PRColor.EncodeColor(color));
		}
	}
}
