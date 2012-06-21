using System.Collections.Generic;
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

		public ProgramFlow(IList<string> args, TextWriter output, HashAlgorithm algorithm)
		{
			_args = args.Count;

			if (args.Count > 0)
				_path = args[0];

			if (args.Count > 1)
				_digest = args[1];

			_algorithm = algorithm;
			_output = output;
		}

		public int Run()
		{
			int ret = 0;

			if (_args == 1 || _args == 2)
			{
				if (File.Exists(_path))
				{
					var checker = new FileDigestChecker(_path, _algorithm);
					string message;

					if (_args == 1)
					{
						message = checker.Generate();
					}
					else
					{
						if (checker.Check(_digest))
						{
							message = "Checksums match.";
						}
						else
						{
							message = "Checksums do not match.";
							ret = 1;
						}
					}

					_output.WriteLine(message);
				}
				else
				{
					_output.WriteLine("File '{0}' not found.", _path);
					ret = -1;
				}
			}
			else
			{
				if (_args > 2)
				{
					_output.WriteLine("Invalid number of arguments.");
					ret = -2;
				}

				_output.WriteLine("Correct usage: {0} <filename> [<digest>]", Assembly.GetExecutingAssembly().GetName().Name);
			}

			return ret;
		}
	}
}