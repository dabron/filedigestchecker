using System;
using System.Security.Cryptography;
using FileDigest;

namespace md5
{
	internal static class Program
	{
		private static int Main(string[] args)
		{
			var flow = new ProgramFlow(args, Console.Out, new MD5Cng());
			return flow.Run();
		}
	}
}