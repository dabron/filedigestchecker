using System;
using System.Security.Cryptography;
using FileDigest;

namespace sha512
{
	internal static class Program
	{
		private static int Main(string[] args)
		{
			var flow = new ProgramFlow(args, Console.Out, new SHA512Cng());
			return flow.Run();
		}
	}
}