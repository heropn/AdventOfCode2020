using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
	static class Day11
	{
		static string pathToFile = @"D:\Visual Studio C# Projects\AdventOfCode2020\Day11\input.txt";
		static string[] lines = System.IO.File.ReadAllLines(pathToFile);

		private enum Direction
		{
			LeftUp,
			Up,
			RightUp,
			Left,
			Right,
			LeftDown,
			Down,
			RightDown
		}
		static private char IsChairClear(List<List<char>> seats, int firstIndex, int secondIndex, Direction direction)
		{
			int i = 1;
			char seat = '.';

			while (true)
			{
				if (firstIndex - i >= 0 && seats[firstIndex - i][secondIndex] != '.' && direction == Direction.Up) // up
				{
					seat = seats[firstIndex - i][secondIndex];
					break;
				}
				else if (firstIndex - i < 0 && direction == Direction.Up)
				{
					break;
				}

				if (firstIndex + i < seats.Count && seats[firstIndex + i][secondIndex] != '.' && direction == Direction.Down) // down
				{
					seat = seats[firstIndex + i][secondIndex];
					break;
				}
				else if (firstIndex + i >= seats.Count && direction == Direction.Down)
				{
					break;
				}

				if (secondIndex + i < seats[firstIndex].Count && seats[firstIndex][secondIndex + i] != '.' && direction == Direction.Right) //right
				{
					seat = seats[firstIndex][secondIndex + i];
					break;
				}
				else if (!(secondIndex + i < seats[firstIndex].Count) && direction == Direction.Right)
				{
					break;
				}

				if (secondIndex - i >= 0 && seats[firstIndex][secondIndex - i] != '.' && direction == Direction.Left) // left
				{
					seat = seats[firstIndex][secondIndex - i];
					break;
				}
				else if (!(secondIndex - i >= 0) && direction == Direction.Left)
				{
					break;
				}

				if (firstIndex - i >= 0 && secondIndex + i < seats[firstIndex].Count && seats[firstIndex - i][secondIndex + i] != '.' && direction == Direction.RightUp) //right up
				{
					seat = seats[firstIndex - i][secondIndex + i];
					break;
				}
				else if (!(firstIndex - i >= 0 && secondIndex + i < seats[firstIndex].Count) && direction == Direction.RightUp)
				{
					break;
				}

				if (firstIndex - i >= 0 && secondIndex - i >= 0 && seats[firstIndex - i][secondIndex - i] != '.' && direction == Direction.LeftUp) //left up
				{
					seat = seats[firstIndex - i][secondIndex - i];
					break;
				}
				else if (!(firstIndex - i >= 0 && secondIndex - i >= 0) && direction == Direction.LeftUp)
				{
					break;
				}

				if (firstIndex + i < seats.Count && secondIndex - i >= 0 && seats[firstIndex + i][secondIndex - i] != '.' && direction == Direction.LeftDown) //left down
				{
					seat = seats[firstIndex + i][secondIndex - i];
					break;
				}
				else if (!(firstIndex + i < seats.Count && secondIndex - i >= 0) && direction == Direction.LeftDown)
				{
					break;
				}

				if (firstIndex + i < seats.Count && secondIndex + i < seats[firstIndex].Count && seats[firstIndex + i][secondIndex + i] != '.' && direction == Direction.RightDown) //right down
				{
					seat = seats[firstIndex + i][secondIndex + i];
					break;
				}
				else if (!(firstIndex + i < seats.Count && secondIndex + i < seats[firstIndex].Count) && direction == Direction.RightDown)
				{
					break;
				}
				i++;
			}

			return seat;
		}

		static private int CheckAdjectentSeat(List<List<char>> seats, int firstIndex, int secondIndex)
		{
			int howManySeatsOccupied = 0;

			if (IsChairClear(seats,firstIndex,secondIndex, Direction.Up) == '#')
			{
				howManySeatsOccupied++;
			}
			if (IsChairClear(seats, firstIndex, secondIndex, Direction.Down) == '#')
			{
				howManySeatsOccupied++;
			}
			if (IsChairClear(seats, firstIndex, secondIndex, Direction.Right) == '#')
			{
				howManySeatsOccupied++;
			}
			if (IsChairClear(seats, firstIndex, secondIndex, Direction.Left) == '#')
			{
				howManySeatsOccupied++;
			}
			if (IsChairClear(seats, firstIndex, secondIndex, Direction.LeftUp) == '#')
			{
				howManySeatsOccupied++;
			}
			if (IsChairClear(seats, firstIndex, secondIndex, Direction.LeftDown) == '#')
			{
				howManySeatsOccupied++;
			}
			if (IsChairClear(seats, firstIndex, secondIndex, Direction.RightDown) == '#')
			{
				howManySeatsOccupied++;
			}
			if (IsChairClear(seats, firstIndex, secondIndex, Direction.RightUp) == '#')
			{
				howManySeatsOccupied++;
			}

			return howManySeatsOccupied;
		}

		static private int HowManyOccupiedSeats(List<List<char>> seats)
		{
			bool hasChanged = true;

			while (hasChanged)
			{
				hasChanged = false;
				List<List<char>> listToReturn = new List<List<char>>();

				for (int i = 0; i < seats.Count; i++)
				{
					listToReturn.Add(new List<char>());
					foreach (var c in seats[i])
					{
						listToReturn[i].Add(c);
					}
				}

				for (int i = 0; i < lines.Length; i++)
				{
					for (int j = 0; j < lines[i].Length; j++)
					{
						if (seats[i][j] == 'L' && CheckAdjectentSeat(seats, i, j) == 0)
						{
							hasChanged = true;
							listToReturn[i][j] = '#';
						}
						else if (seats[i][j] == '#' && CheckAdjectentSeat(seats, i, j) > 3)
						{
							hasChanged = true;
							listToReturn[i][j] = 'L';
						}
					}
				}

				seats = listToReturn;
			}

			int occupiedSeatsCount = 0;

			foreach (var line in seats)
			{
				foreach (var c in line)
				{
					if (c == '#')
					{
						occupiedSeatsCount++;
					}
				}
			}

			return occupiedSeatsCount;
		}

		static public void PrintSolution(int partNumber = 1)
		{
			List<List<char>> seats = new List<List<char>>();

			for (int i = 0; i < lines.Length; i++)
			{
				seats.Add(new List<char>());
				for (int j = 0; j < lines[i].Length; j++)
				{
					seats[i].Add(lines[i][j]);
				}
			}

			if (partNumber == 1)
			{
				Console.WriteLine(HowManyOccupiedSeats(seats));
			}
			else if (partNumber == 2)
			{
				bool hasChanged = true;

				while (hasChanged)
				{
					hasChanged = false;
					List<List<char>> listToReturn = new List<List<char>>();


					for (int i = 0; i < seats.Count; i++)
					{
						listToReturn.Add(new List<char>());
						foreach (var c in seats[i])
						{
							listToReturn[i].Add(c);
						}
					}

					for (int i = 0; i < lines.Length; i++)
					{
						for (int j = 0; j < lines[i].Length; j++)
						{
							if (seats[i][j] == 'L' && CheckAdjectentSeat(seats, i, j) == 0)
							{
								hasChanged = true;
								listToReturn[i][j] = '#';
							}
							else if (seats[i][j] == '#' && CheckAdjectentSeat(seats, i, j) > 4)
							{
								hasChanged = true;
								listToReturn[i][j] = 'L';
							}
						}
					}

					seats = listToReturn;
				}

				int occupiedSeatsCount = 0;

				foreach (var line in seats)
				{
					foreach (var c in line)
					{
						if (c == '#')
						{
							occupiedSeatsCount++;
						}
					}
				}

				Console.WriteLine(occupiedSeatsCount);
			}
		}
	}
}
