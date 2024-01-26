using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using PointLib;

namespace FormsApp
{
	class MyFormat
	{
		private static string Hash(string str)
		{
			return BitConverter.ToString(SHA1.Create().ComputeHash(Encoding.GetEncoding(0).GetBytes(str)));
		}

		public static void Serialize(FileStream fs, Point[] points)
		{
			using (var sw = new StreamWriter(fs))
				points.ToList().ForEach(x => sw.WriteLine(Hash(x.ToString())));
		}
	}
}
