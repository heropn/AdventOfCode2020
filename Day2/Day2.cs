using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2020
{
	static class Day2
	{
		static string pathToFile = @"D:\Visual Studio C# Projects\AdventOfCode2020\Day2\input.txt";
		static string[] lines = System.IO.File.ReadAllLines(pathToFile);
		static public void PrintSolution(int partNumber = 1)
		{
			if (partNumber == 1)
			{
				int validPasswordsCount = 0;

				foreach (var line in lines)
				{
					int min = 0, max = 0;
					char keyword = '0';
					string newLine = line;
					int keywordsInStringCount = 0;

					for (int i = 0; i < newLine.Length; i++)
					{
						if (newLine[i] == '-')
						{
							min = Int16.Parse(newLine.Substring(0, i));
							newLine = newLine.Remove(0, i + 1);
							i = 0;
						}
						else if (newLine[i] == ' ')
						{
							max = Int16.Parse(newLine.Substring(0, i));
							newLine = newLine.Remove(0, i + 1);
							keyword = newLine[0];
							newLine = newLine.Remove(0, 3);
							i = 0;
							break;
						}
					}

					foreach (var c in newLine)
					{
						if (c == keyword)
							keywordsInStringCount++;
					}

					if (keywordsInStringCount >= min && keywordsInStringCount <= max)
					{
						validPasswordsCount++;
					}
				}

				Console.WriteLine(validPasswordsCount);
			}
			else if (partNumber == 2)
			{
				int validPasswordsCount = 0;

				foreach (var line in lines)
				{
					int firstIndex = 0, secondIndex = 0;
					char keyword = '0';
					string newLine = line;

					for (int i = 0; i < newLine.Length; i++)
					{
						if (newLine[i] == '-')
						{
							firstIndex = Int16.Parse(newLine.Substring(0, i)) - 1;
							newLine = newLine.Remove(0, i + 1);
							i = 0;
						}
						else if (newLine[i] == ' ')
						{
							secondIndex = Int16.Parse(newLine.Substring(0, i)) - 1;
							newLine = newLine.Remove(0, i + 1);
							keyword = newLine[0];
							newLine = newLine.Remove(0, 3);
							i = 0;
							break;
						}
					}

					if (newLine[firstIndex] == keyword && newLine[secondIndex] != keyword ||
						newLine[firstIndex] != keyword && newLine[secondIndex] == keyword)
					{
						validPasswordsCount++;
					}
				}

				Console.WriteLine(validPasswordsCount);
			}
		}
	}
}
