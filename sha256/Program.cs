using System;
using System.Security.Cryptography;
using FileDigest;

namespace sha256
{
	internal static class Program
	{
		private static int Main(string[] args)
		{
			var flow = new ProgramFlow(args, Console.Out, new SHA256Cng());
			return flow.Run();
		}
	}
}