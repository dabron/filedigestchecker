using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FileDigest
{
	public class FileDigestChecker
	{
		private readonly string _path;
		private readonly HashAlgorithm _algorithm;

		public FileDigestChecker(string path, HashAlgorithm algorithm)
		{
			_path = path;
			_algorithm = algorithm;
		}

		public bool Check(string digest)
		{
			bool match = false;
			string generated = Generate();
			if (digest == generated)
				match = true;
			return match;
		}

		public string Generate()
		{
			byte[] buffer = File.ReadAllBytes(_path);
			byte[] digest = _algorithm.ComputeHash(buffer);
			string hex = BytesToHex(digest);
			return hex;
		}

		private static string BytesToHex(ICollection<byte> bytes)
		{
			StringBuilder sb = new StringBuilder(bytes.Count * 2);
			foreach (byte b in bytes)
				sb.AppendFormat("{0:x2}", b);
			string hex = sb.ToString();
			return hex;
		}
	}
}
