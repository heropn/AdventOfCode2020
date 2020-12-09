using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
	static class Day3
	{
		static string pathToFile = @"D:\Visual Studio C# Projects\AdventOfCode2020\Day3\input.txt";
		static string[] lines = System.IO.File.ReadAllLines(pathToFile);
		static public void PrintSolution(int partNumber = 1)
		{
			if (partNumber == 1)
			{
				Console.WriteLine(CheckSlope(3, 1));
			}
			else if (partNumber == 2)
			{
				ulong answer = (ulong)(CheckSlope(3, 1));
				answer *= (ulong)CheckSlope(1, 1);
				answer *= (ulong)CheckSlope(5, 1);
				answer *= (ulong)CheckSlope(7, 1);
				answer *= (ulong)CheckSlope(1, 2);

				Console.WriteLine(answer);
			}
		}

		static int CheckSlope(int rightMove, int downMove)
		{
			int treesCount = 0;
			int lineLength = lines[0].Length;
			int index = 0;

			for (int i = 0; i < lines.Length; i += downMove)
			{
				if (index >= lineLength)
				{
					index %= lineLength;
				}
				else if (i == 0)
				{
					index = 0;
				}

				if (lines[i][index] == '#')
				{
					treesCount++;
				}
				index += rightMove;
			}

			return treesCount;
		}
	}
}
