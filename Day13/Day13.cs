using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace AdventOfCode2020
{
	static class Day13
	{
		static string pathToFile = @"D:\Visual Studio C# Projects\AdventOfCode2020\Day13\input.txt";
		static string[] lines = File.ReadAllLines(pathToFile);

		class Bus
		{
			public bool isX = false;
			public uint value;

			public Bus(uint value)
			{
				this.value = value;
			}
		}

		static public void PrintSolution(int partNumber = 1)
		{
			if (partNumber == 1)
			{
				int startTime = Int32.Parse(lines[0]);
				var buses = Regex.Matches(lines[1], @"\d+").Select(m => int.Parse(m.Value)).ToList();
				bool isFound = false;
				int i = 0;

				while (!isFound)
				{
					foreach (var num in buses)
					{
						if ((startTime + i) % num == 0)
						{
							Console.WriteLine(num * i);
							isFound = true;
							break;
						}
					}
					i++;
				}
			}
			else if (partNumber == 2)
			{
				var splittedValues = Regex.Split(lines[1], "(,)").ToList();
				splittedValues.RemoveAll(a => a == ",");
				List<Bus> optimizedList = new List<Bus>();
				bool isFound = false;
				ulong i = 100000000000000;
				uint sum = 0;
				int startIndex = 0;

				for (int j = 0; j < splittedValues.Count; j++)
				{
					if (splittedValues[j] == "x")
					{
						sum++;
					}
					else
					{
						if (sum != 0)
						{
							optimizedList.Add(new Bus(sum));
							optimizedList[optimizedList.Count - 1].isX = true;
						}
						optimizedList.Add(new Bus(UInt32.Parse(splittedValues[j])));
						sum = 0;
						startIndex = j + 1;
					}
				}

				while (!isFound)
				{
					i += optimizedList[0].value;
					uint diff = 0;
					isFound = true;

					foreach (var bus in optimizedList)
					{
						if (bus.isX)
						{
							diff += bus.value;
						}
						else
						{
							if (!((i + diff) % bus.value == 0))
							{
								isFound = false;
								break;
							}
							diff++;
						}
					}
				}
				Console.WriteLine(i);
			}
		}
	}
}
