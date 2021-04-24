using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
	static class Day7
	{
		static string pathToFile = @"D:\Visual Studio C# Projects\AdventOfCode2020\Day7\input.txt";
		static string[] lines = System.IO.File.ReadAllLines(pathToFile);

		class Bag
		{
			public string name;
			public List<Bag> containedBags = new List<Bag>();
			public List<int> containedBagsCount = new List<int>();

			public Bag(string name)
			{
				this.name = name;
			}

			public bool CheckIfContainsShinyBag()
			{
				foreach (var bag in containedBags)
				{
					if (bag.name == "shiny gold" || bag.CheckIfContainsShinyBag())
					{
						return true;
					}
				}

				return false;
			}

			public int HowManyBagsInside()
			{
				int sum = 0;

				for (int i = 0; i < containedBags.Count; i++)
				{
					for (int j = 0; j < containedBagsCount[i]; j++)
					{
						sum += containedBags[i].HowManyBagsInside() + 1;
					}
				}

				return sum;
			}
		}

		static public void PrintSolution(int partNumber = 1)
		{
			if (partNumber == 1)
			{
				List<Bag> bags = new List<Bag>();

				foreach(var line in lines)
				{
					string[] wordsInLine = line.Split();

					int index = -1;

					foreach (var bag in bags)
					{
						if (bag.name == wordsInLine[0] + " " + wordsInLine[1])
						{
							index = bags.IndexOf(bag);
							break;
						}
					}

					if (index == -1)
					{
						index = bags.Count;
						bags.Add(new Bag(wordsInLine[0] + " " + wordsInLine[1]));
					}

					for (int i = 3; i < wordsInLine.Length; i++)
					{
						if (wordsInLine[i] == "bag," || wordsInLine[i] == "bags." || wordsInLine[i] == "bag." || wordsInLine[i] == "bags,")
						{
							bool foundBag = false;

							foreach (var bag in bags)
							{
								if (bag.name == wordsInLine[i - 2] + " " + wordsInLine[i - 1])
								{
									bags[index].containedBags.Add(bag);
									foundBag = true;
									break;
								}
							}

							if (!foundBag)
							{
								bags.Add(new Bag(wordsInLine[i - 2] + " " + wordsInLine[i - 1]));
								bags[index].containedBags.Add(bags[bags.Count - 1]);
							}
						}
					}
				}

				int count = 0;

				foreach (var bag in bags)
				{
					if (bag.CheckIfContainsShinyBag())
					{
						count++;
					}
				}

				Console.WriteLine(count);
			}
			else if (partNumber == 2)
			{
				List<Bag> bags = new List<Bag>();

				foreach (var line in lines)
				{
					string[] wordsInLine = line.Split();

					int index = -1;

					foreach (var bag in bags)
					{
						if (bag.name == wordsInLine[0] + " " + wordsInLine[1])
						{
							index = bags.IndexOf(bag);
							break;
						}
					}

					if (index == -1)
					{
						index = bags.Count;
						bags.Add(new Bag(wordsInLine[0] + " " + wordsInLine[1]));
					}

					for (int i = 3; i < wordsInLine.Length; i++)
					{
						if (wordsInLine[i] == "bag," || wordsInLine[i] == "bags." || wordsInLine[i] == "bag." || wordsInLine[i] == "bags,")
						{
							bool foundBag = false;

							if (wordsInLine[i - 2] == "no")
							{
								break;
							}

							foreach (var bag in bags)
							{
								if (bag.name == wordsInLine[i - 2] + " " + wordsInLine[i - 1])
								{
									bags[index].containedBags.Add(bag);
									bags[index].containedBagsCount.Add(Int16.Parse(wordsInLine[i - 3]));
									foundBag = true;
									break;
								}
							}

							if (!foundBag)
							{
								bags.Add(new Bag(wordsInLine[i - 2] + " " + wordsInLine[i - 1]));
								bags[index].containedBags.Add(bags[bags.Count - 1]);
								bags[index].containedBagsCount.Add(Int16.Parse(wordsInLine[i - 3]));
							}
						}
					}
				}

				int count = 0;

				var shinyGoldBag = bags.Find(a => a.name == "shiny gold");

				count = shinyGoldBag.HowManyBagsInside();

				Console.WriteLine(count);
			}
		}
	}
}
