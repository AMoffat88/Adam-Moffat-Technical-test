using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdamMoffatTechnicalTest
{
	class PrenumtationsTest
	{
		private static void Swap(ref char a, ref char b)
		{
			if (a == b) return;

			var temp = a;
			a = b;
			b = temp;
		}

		public static void GetPer(char[] list)
		{
			int x = list.Length - 1;
			GetPer(list, 0, x);
		}

		private static void GetPer(char[] list, int k, int m)
		{
			if (k == m)
			{
				Console.Write(list);
				Console.WriteLine("\t");
			}
			else
				for (int i = k; i <= m; i++)
				{
					Swap(ref list[k], ref list[i]);
					GetPer(list, k + 1, m);
					Swap(ref list[k], ref list[i]);
				}
		}

		public PrenumtationsTest(string input)
		{
			char[] arr = input.ToCharArray();
			GetPer(arr);
		}
	}
}
