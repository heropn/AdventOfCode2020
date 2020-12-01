using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
	static class Day1
	{
		static string pathToFile = @"D:\Visual Studio C# Projects\AdventOfCode2020\Day1\input.txt";
		static string[] lines = System.IO.File.ReadAllLines(pathToFile);

		static public void PrintSolution(int partNumber = 1)
		{
			List<int> numbers = new List<int>();

			foreach (var line in lines)
			{
				numbers.Add(Int32.Parse(line));
			}

			if (partNumber == 1)
			{
				foreach (var num in numbers)
				{
					var numb = numbers.FirstOrDefault(a => a + num == 2020);
					if (numb != 0)
					{
						Console.WriteLine(numb * num);
						return;
					}
				}
			}
			else if (partNumber == 2)
			{
				for (int i = 0; i < numbers.Count; i++)
				{
					for (int j = i + 1; j < numbers.Count; j++)
					{
						var numb = numbers.FirstOrDefault(a => a + numbers[i] + numbers[j] == 2020);
						if (numb != 0)
						{
							Console.WriteLine(numb * numbers[i] * numbers[j]);
							return;
						}
					}
				}
			}
		}
	}
}
