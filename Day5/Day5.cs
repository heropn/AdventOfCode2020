using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2020
{
	static class Day5
	{
		static string pathToFile = @"D:\Visual Studio C# Projects\AdventOfCode2020\Day5\input.txt";
		static string[] lines = System.IO.File.ReadAllLines(pathToFile);
		static public void PrintSolution(int partNumber = 1)
		{
			List<string> linesL = new List<string>(lines.ToList());
			List<int> seatsID = new List<int>();

			for (int i = 0; i < linesL.Count; i++)
			{
				int seatID = 0;
				//string binaryString = "";

				for (int j = 0; j < linesL[i].Length; j++)
				{
					if (linesL[i][j] == 'F' || linesL[i][j] == 'L')
					{
						seatID *= 2;
						//binaryString += '0';
					}
					else
					{
						seatID = (seatID * 2) + 1;
						//binaryString += '1';
					}
				}
				seatsID.Add(seatID);
			}

			if (partNumber == 1)
			{
				Console.WriteLine(seatsID.Max(a => a));
			}
			else if (partNumber == 2)
			{
				seatsID.Sort();

				for (int i = 1; i < seatsID.Count; i++)
				{
					if (seatsID[i] - seatsID[i - 1] == 2)
					{
						Console.WriteLine(seatsID[i] - 1);
						break;
					}
				}
			}
		}
	}
}
