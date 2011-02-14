using System.IO;
using System.Reflection;
using System.Security.Cryptography;

namespace FileDigest
{
	public class ProgramFlow
	{
		private readonly int _args;
		private readonly string _path;
		private readonly string _digest;
		private readonly HashAlgorithm _algorithm;
		private readonly TextWriter _output;

		public ProgramFlow(string[] args, TextWriter output, HashAlgorithm algorithm)
		{
			_args = args.Length;

			if (args.Length > 0)
				_path = args[0];

			if (args.Length > 1)
				_digest = args[1];

			_algorithm = algorithm;
			_output = output;
		}

		public void Run()
		{
			if (_args > 0 && _args <= 2)
			{
				if (File.Exists(_path))
				{
					var checker = new FileDigestChecker(_path, new SHA1Cng());
					string message = _args == 1 ? checker.Generate() : checker.Check(_digest) ? "Checksums match." : "Checksums do not match.";
					_output.WriteLine(message);
				}
				else
				{
					_output.WriteLine("File '{0}' not found.", _path);
				}
			}
			else
			{
				if (_args > 2)
					_output.WriteLine("Invalid number of arguments.");
				_output.WriteLine("Correct usage: {0} <filename> [<digest>]", Assembly.GetExecutingAssembly().GetName().Name);
			}
		}
	}
}
