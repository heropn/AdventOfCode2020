using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
	static class Day1
	{
		static string pathToFile = @"D:\Visual Studio C# Projects\AdventOfCode2020\Day1\input.txt";
		static string[] lines = System.IO.File.ReadAllLines(pathToFile);
		static public void PrintPartOneSolution()
		{
			for (int i = 0; i < lines.Length; i++)
			{
				for (int j = i + 1; j < lines.Length; j++)
				{
					if (Int32.Parse(lines[i]) + Int32.Parse(lines[j]) == 2020)
					{
						Console.WriteLine(Int32.Parse(lines[i]) * Int32.Parse(lines[j]));
					}
				}
			}
		}

		static public void PrintPartTwoSolution()
		{
			for (int i = 0; i < lines.Length; i++)
			{
				for (int j = i + 1; j < lines.Length; j++)
				{
					for (int u = j + 1; u < lines.Length; u++)
					if (Int32.Parse(lines[i]) + Int32.Parse(lines[j]) + Int32.Parse(lines[u]) == 2020)
					{
						Console.WriteLine(Int64.Parse(lines[i]) * Int64.Parse(lines[j]) * Int32.Parse(lines[u]));
					}
				}
			}
		}
	}
}
