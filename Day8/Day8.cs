using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
	static class Day8
	{
		class Instruction
		{
			public enum Type
			{
				nop,
				acc,
				jmp
			}

			public Type type;
			public int value;
			public bool isVisted;

			public Instruction(string instructionName, int value)
			{
				this.value = value;
				isVisted = false;

				if (instructionName == "nop")
				{
					type = Type.nop;
				}
				else if (instructionName == "acc")
				{
					type = Type.acc;
				}
				else if (instructionName == "jmp")
				{
					type = Type.jmp;
				}
			}
		}

		static string pathToFile = @"D:\Visual Studio C# Projects\AdventOfCode2020\Day8\input.txt";
		static string[] lines = System.IO.File.ReadAllLines(pathToFile);
		static public void PrintSolution(int partNumber = 1)
		{
			List<Instruction> instructions = new List<Instruction>();

			foreach (var line in lines)
			{
				int spaceIndex = line.IndexOf(' ');
				Instruction instruction = new Instruction(line.Substring(0, spaceIndex), Int16.Parse(line.Substring(spaceIndex + 1)));
				instructions.Add(instruction);
			}

			if (partNumber == 1)
			{
				int accumulatorValue = 0;

				for (int i = 0; i < instructions.Count; i += 0)
				{
					if (instructions[i].isVisted)
					{
						break;
					}

					instructions[i].isVisted = true;

					if (instructions[i].type == Instruction.Type.acc)
					{
						accumulatorValue += instructions[i].value;
						i++;
					}
					else if (instructions[i].type == Instruction.Type.jmp)
					{
						i += instructions[i].value;
					}
					else
					{
						i++;
					}
				}

				Console.WriteLine(accumulatorValue);
			}
			else if (partNumber == 2)
			{
				for (int i = 0; i < instructions.Count; i++)
				{
					if ((instructions[i].type == Instruction.Type.jmp &&
						TryChange(instructions, i, Instruction.Type.nop) ||
						(instructions[i].type == Instruction.Type.nop &&
						TryChange(instructions, i, Instruction.Type.jmp))))
					{
						break;
					}
				}
			}
		}

		private static bool TryChange(List<Instruction> instructions, int index, Instruction.Type type)
		{
			int accumulatorValue = 0;
			bool isValid = true;
			Instruction.Type typeBefore = instructions[index].type;

			instructions[index].type = type;

			for (int i = 0; i < instructions.Count; i += 0)
			{
				if (instructions[i].isVisted)
				{ 
					isValid = false;
					break;
				}

				instructions[i].isVisted = true;

				if (instructions[i].type == Instruction.Type.acc)
				{
					accumulatorValue += instructions[i].value;
					i++;
				}
				else if (instructions[i].type == Instruction.Type.jmp)
				{
					i += instructions[i].value;
				}
				else
				{
					i++;
				}
			}

			//foreach(va)

			if (isValid)
			{
				Console.WriteLine(accumulatorValue);
				return true;
			}
			else
			{
				foreach (var instruction in instructions)
				{
					instruction.isVisted = false;
				}

				instructions[index].type = typeBefore;

				return false;
			}
		}
	}
}
