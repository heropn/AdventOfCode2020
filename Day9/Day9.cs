using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2020
{
	static class Day9
	{
		static string pathToFile = @"D:\Visual Studio C# Projects\AdventOfCode2020\Day9\input.txt";
		static string[] lines = System.IO.File.ReadAllLines(pathToFile);
		static public void PrintSolution(int partNumber = 1)
		{
			if (partNumber == 1)
			{
				List<ulong> numbers = new List<ulong>();

				foreach (var line in lines)
				{
					ulong num = ulong.Parse(line);

					numbers.Add(num);

					if (numbers.Count > 25)
					{
						bool isFound = false;
						foreach (var number in numbers)
						{
							var answer = numbers.FirstOrDefault(a => a + number == num);

							if (answer != 0)
							{
								isFound = true;
								break;
							}
						}
						
						if (isFound)
						{
							numbers.RemoveAt(0);
						}
						else
						{
							Console.WriteLine(num);
							break;
						}
					}

				}
			}
			else if (partNumber == 2)
			{
				List<ulong> numbers = new List<ulong>();

				ulong lookedNumber = 20874512;
				//ulong lookedNumber = 127;
				ulong actualNumber = 0;
				int startIndex = 0;

				foreach (var line in lines)
				{
					ulong num = ulong.Parse(line);
					numbers.Add(num);
				}

				List<ulong> answerNumbers = new List<ulong>();

				for (int i = startIndex; i < numbers.Count; i++)
				{
					actualNumber += numbers[i];
					answerNumbers.Add(numbers[i]);

					if (actualNumber > lookedNumber)
					{
						i = startIndex++;
						actualNumber = 0;
						answerNumbers.Clear();
					}
					else if (actualNumber == lookedNumber)
					{
						Console.WriteLine(answerNumbers.Min() + answerNumbers.Max());
						break;
					}
				}
			}
		}
	}
}
