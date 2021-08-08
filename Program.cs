using System;
using System.IO;
using GBX.NET;
using GBX.NET.Engines.Game;
using GBX.NET.LZO;

namespace tm_ghost_tool
{
	class Program
	{
		static void Main(string[] args)
		{
			foreach (var filePath in args)
			{
				Console.WriteLine($"Updating {filePath}");
				try
				{
					ProcessFile(filePath);
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
			}
		}

		private static void ProcessFile(string path)
		{
			var map = GameBox.ParseNode<CGameCtnChallenge>(path);
			map.ChallengeParameters.RaceValidateGhost = null;
			SaveMap(map, path);
		}

		private static void SaveMap(CGameCtnChallenge map, string sourcePath)
		{
			var outDirectory = Path.Join(Path.GetDirectoryName(sourcePath), "NoGhost");
			var outPath = Path.Join(outDirectory, Path.GetFileName(sourcePath));

			Directory.CreateDirectory(outDirectory);
			map.Save(outPath);
		}
	}
}