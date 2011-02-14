using System;
using System.Security.Cryptography;
using FileDigest;

namespace md5
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var flow = new ProgramFlow(args, Console.Out, new MD5Cng());
			flow.Run();
		}
	}
}
