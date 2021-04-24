using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
	static class Day12
	{
		static string pathToFile = @"D:\Visual Studio C# Projects\AdventOfCode2020\Day12\input.txt";
		static string[] lines = System.IO.File.ReadAllLines(pathToFile);

		private class Ship
		{
			private int north = 0;
			private int east = 0;
			private int rotationInDegreeFromNortToRight = 90;
			private int waypointEast = 10;
			private int waypointNorth = 1;
			private int quarter = 3;

			private Direction facingDirection = Direction.East;

			public enum Direction
			{
				North,
				East,
				South,
				West
			}

			public void MakeOrder(char order, int value)
			{
				if (order == 'N' || order == 'S' || order == 'E' || order == 'W')
				{
					if (order == 'N')
					{
						Move(Direction.North, value);
					}
					else if (order == 'S')
					{
						Move(Direction.South, value);
					}
					else if (order == 'E')
					{
						Move(Direction.East, value);
					}
					else if (order == 'W')
					{
						Move(Direction.West, value);
					}
				}
				else if (order == 'R' || order == 'L')
				{
					Rotate(order, value);
				}
				else if (order == 'F')
				{
					Move(facingDirection, value);
				}
			}

			public void MakeOrderPart2(char order, int value)
			{
				if (order == 'N' || order == 'S' || order == 'E' || order == 'W')
				{
					if (order == 'N')
					{
						MoveWaypoint(Direction.North, value);
					}
					else if (order == 'S')
					{
						MoveWaypoint(Direction.South, value);
					}
					else if (order == 'E')
					{
						MoveWaypoint(Direction.East, value);
					}
					else if (order == 'W')
					{
						MoveWaypoint(Direction.West, value);
					}
				}
				else if (order == 'R' || order == 'L')
				{
					RotateWaypoint(order, value);
				}
				else if (order == 'F')
				{
					north += (waypointNorth * value);
					east += (waypointEast * value);
				}
			}

			private void MoveWaypoint(Direction direction, int value)
			{
				if (direction == Direction.North)
				{
					this.waypointNorth += value;
				}
				else if (direction == Direction.South)
				{
					this.waypointNorth -= value;
				}
				else if (direction == Direction.East)
				{
					this.waypointEast += value;
				}
				else if (direction == Direction.West)
				{
					this.waypointEast -= value;
				}
			}

			private void RotateWaypoint(char side, int value)
			{
				if (side == 'L')
				{
					int actualQuarter = quarter;
					quarter -= (value / 90);

					if (quarter < 1)
					{
						quarter += 4;
					}

					while (actualQuarter != quarter)
					{
						if ((actualQuarter - 1) % 4 == 1 || (actualQuarter - 1) % 4 == 0)
						{
							int oldWaypointEast = waypointEast;
							int oldWaypointNorth = waypointNorth;
							waypointEast = -oldWaypointNorth;
							waypointNorth = oldWaypointEast;
						}
						else if ((actualQuarter - 1) % 4 == 2 || (actualQuarter - 1) % 4 == 3)
						{
							int oldWaypointEast = waypointEast;
							int oldWaypointNorth = waypointNorth;
							waypointEast = -oldWaypointNorth;
							waypointNorth = oldWaypointEast;
						}
						actualQuarter--;
						if (actualQuarter < 1)
						{
							actualQuarter = 4;
						}
					}
				}
				else if (side == 'R')
				{
					int actualQuarter = quarter;
					quarter += (value / 90);

					if (quarter > 4)
					{
						quarter %= 4;
					}

					while (actualQuarter != quarter)
					{
						if ((actualQuarter + 1) % 4 == 1 || (actualQuarter + 1) % 4 == 0)
						{
							int oldWaypointEast = waypointEast;
							int oldWaypointNorth = waypointNorth;
							waypointEast = oldWaypointNorth;
							waypointNorth = -oldWaypointEast;
						}
						else if ((actualQuarter + 1) % 4 == 2 || (actualQuarter + 1) % 4 == 3)
						{
							int oldWaypointEast = waypointEast;
							int oldWaypointNorth = waypointNorth;
							waypointEast = oldWaypointNorth;
							waypointNorth = -oldWaypointEast;
						}
						actualQuarter++;
						if (actualQuarter > 4)
						{
							actualQuarter = 1;
						}
					}

				}
			}

			private void Move(Direction direction, int value)
			{
				if (direction == Direction.North)
				{
					this.north += value;
				}
				else if (direction == Direction.South)
				{
					this.north -= value;
				}
				else if (direction == Direction.East)
				{
					this.east += value;
				}
				else if (direction == Direction.West)
				{
					this.east -= value;
				}
			}

			private void Rotate(char side, int value)
			{
				if (side == 'L')
				{
					rotationInDegreeFromNortToRight -= value;

					if (rotationInDegreeFromNortToRight < 0)
					{
						rotationInDegreeFromNortToRight += 360;
					}
				}
				else if (side == 'R')
				{
					rotationInDegreeFromNortToRight += value;

					if (rotationInDegreeFromNortToRight >= 360)
					{
						rotationInDegreeFromNortToRight -= 360;
					}
				}

				if (rotationInDegreeFromNortToRight == 0)
				{
					facingDirection = Direction.North;
				}
				else if (rotationInDegreeFromNortToRight == 90)
				{
					facingDirection = Direction.East;
				}
				else if (rotationInDegreeFromNortToRight == 180)
				{
					facingDirection = Direction.South;
				}
				else if (rotationInDegreeFromNortToRight == 270)
				{
					facingDirection = Direction.West;
				}
			}

			public int GetAnswer()
			{
				return Math.Abs(this.north) + Math.Abs(this.east);
			}
		}

		static public void PrintSolution(int partNumber = 1)
		{
			if (partNumber == 1)
			{
				Ship ship = new Ship();
				foreach (var line in lines)
				{
					char order = line[0];
					int value = Int32.Parse(line.Substring(1));
					ship.MakeOrder(order, value);
				}
				Console.WriteLine(ship.GetAnswer());
			}
			else if (partNumber == 2)
			{
				Ship ship = new Ship();
				foreach (var line in lines)
				{
					char order = line[0];
					int value = Int32.Parse(line.Substring(1));
					ship.MakeOrderPart2(order, value);
				}
				Console.WriteLine(ship.GetAnswer());
			}
		}
	}
}
