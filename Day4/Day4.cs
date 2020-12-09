using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
	class Passport
	{
		public string byr = "";
		public string iyr = "";
		public string eyr = "";
		public string hgt = "";
		public string hcl = "";
		public string ecl = "";
		public string pid = "";

		private List<string> eyeColors = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth"};

		public bool IsDataValid()
		{
			if (Regex.IsMatch(byr, @"\b([1][9][2-9][0-9]|[2][0][0][0-2])\b") &&
				Regex.IsMatch(eyr, @"\b([2][0][2][0-9]|[2][0][3][0])\b") &&
				Regex.IsMatch(hcl, @"^[#][\d|a-f][\d|a-f][\d|a-f][\d|a-f][\d|a-f][\d|a-f]") &&
				Regex.IsMatch(hgt, @"\b(([1][5-8][0-9]cm)|([1][9][0-3]cm)|([5][9]in)|([6][0-9]in)|([7][0-6]in))\b") &&
				Regex.IsMatch(iyr, @"\b([2][0][1][0-9]|[2][0][2][0])\b") &&
				Regex.IsMatch(pid, @"\d+") && pid.Length == 9 &&
				eyeColors.Exists(a => a == ecl))
			{
				return true;
			}

			return false;
		}
	}
	static class Day4
	{
		static string pathToFile = @"D:\Visual Studio C# Projects\AdventOfCode2020\Day4\input.txt";
		static string[] lines = System.IO.File.ReadAllLines(pathToFile);
		static public void PrintSolution(int partNumber = 1)
		{
			List<string> keywords = new List<string> { "byr:", "iyr:", "eyr:", "hgt:", "hcl:", "ecl:", "pid:" };

			if (partNumber == 1)
			{
				List<string> uncheckedKeywords = keywords.Select(a => a).ToList();
				int validPassportCount = 0;

				foreach(var line in lines)
				{
					if (line.Length == 0)
					{
						if (uncheckedKeywords.Count == 0)
						{
							validPassportCount++;
						}
						uncheckedKeywords = keywords.Select(a => a).ToList();
					}
					else
					{
						for (int i = 0; i < uncheckedKeywords.Count; i++)
						{
							if (line.Contains(uncheckedKeywords[i]))
							{
								uncheckedKeywords.RemoveAt(i);
								i--;
							}
						}
					}
				}

				if (uncheckedKeywords.Count == 0)
				{
					validPassportCount++;
				}

				Console.WriteLine(validPassportCount);
			}
			else if (partNumber == 2)
			{
				List<string> uncheckedKeywords = keywords.Select(a => a).ToList();
				int validPassportCount = 0;
				Passport passport = new Passport();

				foreach (var line in lines)
				{
					if (line.Length == 0)
					{
						if (passport.IsDataValid())
						{
							validPassportCount++;
						}
						uncheckedKeywords = keywords.Select(a => a).ToList();
						passport = new Passport();
					}
					else
					{
						var splittedLine = line.Split(':', ' ');

						for (int i = 0; i < splittedLine.Length; i++)
						{
							if (splittedLine[i] == "byr")
							{
								passport.byr = splittedLine[i+1];
								i++;
							}
							else if (splittedLine[i] == "iyr")
							{
								passport.iyr = splittedLine[i + 1];
								i++;
							}
							else if (splittedLine[i] == "eyr")
							{
								passport.eyr = splittedLine[i + 1];
								i++;
							}
							else if (splittedLine[i] == "hgt")
							{
								passport.hgt = splittedLine[i + 1];
								i++;
							}
							else if (splittedLine[i] == "hcl")
							{
								passport.hcl = splittedLine[i + 1];
								i++;
							}
							else if (splittedLine[i] == "ecl")
							{
								passport.ecl = splittedLine[i + 1];
								i++;
							}
							else if (splittedLine[i] == "pid")
							{
								passport.pid = splittedLine[i + 1];
								i++;
							}
						}
					}
				}

				if (passport.IsDataValid())
				{
					validPassportCount++;
				}

				Console.WriteLine(validPassportCount);
			}
		}
	}
}
