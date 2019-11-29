using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdamMoffatTechnicalTest
{
	class StringTextTechTest
	{
		public class PairedDataStruct
		{
			public PairedDataStruct()
			{ }
			public char CharVal;
			public int intValue;
			public int occurenceTimes;
		}
		public StringTextTechTest()
		{

		}

		public void TechTestOne(string charString)
		{
			var safeString = charString;
			//first split string into thier base elements
			var result = safeString
				.Aggregate(" ", (seed, next) => seed + (seed.Last() == next ? "" : " ") + next)
				.Trim()
				.Split(' ');
			var dataStructs = new List<PairedDataStruct>();
			for (int count = 0; count < result.Length; count++)
			{
				var localChar = result[count][0];

				int occurenceCount = 0;

				for (int tempBackCounter = count; tempBackCounter >= 0; tempBackCounter--)
				{
					if (localChar.Equals(result[tempBackCounter][0]))
					{
						occurenceCount = occurenceCount + 1;
					}
				}

				byte[] asciiValue = Encoding.ASCII.GetBytes(localChar.ToString());
				foreach (byte b in asciiValue)
				{
					//calculate the appropriate value desired
					var pds = new PairedDataStruct();
					pds.CharVal = localChar;
					pds.intValue = b * occurenceCount;
					pds.occurenceTimes = occurenceCount;


					dataStructs.Add(pds);
				}
				occurenceCount = 0; // this ensures that the occurence count it set back to 0;
			}
			int totalValue = 0;
			foreach (var element in dataStructs)
			{
				Console.WriteLine("Char Val " + element.CharVal + ": int val " + element.intValue + ". Times Occured Previously: " + element.occurenceTimes);
				totalValue = element.intValue + totalValue;
			}
			Console.WriteLine("Total Value:       " + totalValue.ToString());

		}
	}
}
