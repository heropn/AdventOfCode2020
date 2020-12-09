using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
	static class Day6
	{
		static string pathToFile = @"D:\Visual Studio C# Projects\AdventOfCode2020\Day6\input.txt";
		static string[] lines = System.IO.File.ReadAllLines(pathToFile);
		static public void PrintSolution(int partNumber = 1)
		{
			if (partNumber == 1)
			{
				string password = "";
				List<char> answeredQuestions = new List<char>();
				int questionAnsweredYes = 0;

				foreach (var line in lines)
				{
					if (line.Length == 0)
					{
						foreach (var c in password)
						{
							if (!answeredQuestions.Contains(c))
							{
								answeredQuestions.Add(c);
							}
						}

						questionAnsweredYes += answeredQuestions.Count;
						answeredQuestions.Clear();
						password = "";
						continue;
					}

					password += line;
				}

				foreach (var c in password)
				{
					if (!answeredQuestions.Contains(c))
					{
						answeredQuestions.Add(c);
					}
				}
				questionAnsweredYes += answeredQuestions.Count;

				Console.WriteLine(questionAnsweredYes);
			}
			else if (partNumber == 2)
			{
				List<string> personsAnswers = new List<string>();
				int questionAnsweredYes = 0;

				for(int u = 0; u < lines.Length; u++)
				{
					if (lines[u].Length == 0 || u == lines.Length - 1)
					{
						for (int i = 0; i < personsAnswers[0].Length; i++)
						{
							bool isAnsweredYes = true;

							for (int j = 1; j < personsAnswers.Count; j++)
							{
								if (!personsAnswers[j].Contains(personsAnswers[0][i]))
								{
									isAnsweredYes = false;
									break;
								}
							}

							if (isAnsweredYes)
							{
								questionAnsweredYes++;
							}
						}
						personsAnswers.Clear();
						continue;
					}

					personsAnswers.Add(lines[u]);
					
				}
				Console.WriteLine(questionAnsweredYes);
			}
		}
	}
}
