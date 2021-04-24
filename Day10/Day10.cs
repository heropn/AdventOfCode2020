using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2020
{
	static class Day10
	{
		static private ulong HowManyBranches(List<int> numbers, int index = 0)
		{
			ulong howManyBranches = 0;

			var k = numbers.Where(a => a - numbers[index] <= 3 && a - numbers[index] > 0).ToList();
			if (k.Count > 0)
			{
				howManyBranches += (ulong)(k.Count - 1);
			}

			foreach(var num in k)
			{
				howManyBranches += HowManyBranches(numbers, numbers.IndexOf(num));
			}

			if (index == 0)
			{
				howManyBranches++;
			}

			return howManyBranches;
		}

		static private ulong HowManyBranchesTWO(List<int> numbers)
		{
			List<ulong> branchesCount = new List<ulong>();

			for (int i = 0; i < numbers.Count; i++)
			{
				branchesCount.Add(0);
			}

			branchesCount[0] = 1;

			for (int i = 0; i < numbers.Count; i++)
			{
				for (int j = 0; j < i; j++)
				{
					if (numbers[i] - numbers[j] <= 3)
					{
						branchesCount[i] += branchesCount[j];
					}
				}
			}
			return branchesCount.Max();
		}

		static string pathToFile = @"D:\Visual Studio C# Projects\AdventOfCode2020\Day10\input.txt";
		static string[] lines = System.IO.File.ReadAllLines(pathToFile);

		static public void PrintSolution(int partNumber = 1)
		{
			List<int> adaptersValues = new List<int>();
			adaptersValues.Add(0);

			foreach (var line in lines)
			{
				adaptersValues.Add(Int16.Parse(line));
			}

			adaptersValues.Sort();

			if (partNumber == 1)
			{
				int oneDiffrencesCount = 0;
				int ThreeDiffrencesCount = 1;

				for (int i = 1; i < adaptersValues.Count; i++)
				{
					if (adaptersValues[i] - adaptersValues[i-1] == 1)
					{
						oneDiffrencesCount++;
					}
					else if (adaptersValues[i] - adaptersValues[i - 1] == 3)
					{
						ThreeDiffrencesCount++;
					}
				}

				Console.WriteLine(ThreeDiffrencesCount * oneDiffrencesCount);
			}
			else if (partNumber == 2)
			{
				Console.WriteLine(HowManyBranchesTWO(adaptersValues));
			}
		}
	}
}
