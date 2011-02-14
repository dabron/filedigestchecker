using System;
using System.Security.Cryptography;
using FileDigest;

namespace sha1
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var flow = new ProgramFlow(args, Console.Out, new SHA1Cng());
			flow.Run();
		}
	}
}
