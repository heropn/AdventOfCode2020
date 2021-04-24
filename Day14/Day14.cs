using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
	static class Day14
	{
		static string pathToFile = @"D:\Visual Studio C# Projects\AdventOfCode2020\Day14\input.txt";
		static string[] lines = System.IO.File.ReadAllLines(pathToFile);

		class MemorySlot
		{
			public int slot;
			public ulong value;

			public MemorySlot(int slot, ulong value)
			{
				this.slot = slot;
				this.value = value;
			}

			public void ChangeValueWithMask(string mask)
			{
				for (int i = 0; i < mask.Length; i++)
				{
					if (mask[i] != 'X')
					{
						if (mask[i] == '1')
						{
							value = value | ((ulong)1 << i);
						}
						else
						{
							value = value & ~((ulong)1 << i);
						}
					}
				}
			}
		}

		static public void PrintSolution(int partNumber = 1)
		{
			if (partNumber == 1)
			{
				string mask = "";
				List<MemorySlot> memorySlots = new List<MemorySlot>();

				foreach (var line in lines)
				{
					if (line.Contains("mask"))
					{
						mask = line.Substring(7);
						char[] cArray = mask.ToCharArray();
						Array.Reverse(cArray);
						mask = new string(cArray);
					}
					else
					{
						int startIndex = line.IndexOf('[');
						int length = line.IndexOf(']') - startIndex;
						int memorySlotValue = Int32.Parse(line.Substring(startIndex + 1, length - 1));
						startIndex = line.IndexOf('=');
						ulong value = ulong.Parse(line.Substring(startIndex + 2));
						bool isFound = false;

						foreach (var ms in memorySlots)
						{
							if (ms.slot == memorySlotValue)
							{
								isFound = true;

								ms.value = value;
								ms.ChangeValueWithMask(mask);
							}
						}

						if (!isFound)
						{
							memorySlots.Add(new MemorySlot(memorySlotValue, value));
							memorySlots[memorySlots.Count - 1].ChangeValueWithMask(mask);
						}
					}
				}

				ulong sum = 0;

				foreach (var mem in memorySlots)
				{
					sum += mem.value;
				}

				Console.WriteLine(sum);
			}
			else if (partNumber == 2)
			{
				
			}
		}
	}
}
