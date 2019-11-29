using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdamMoffatTechnicalTest
{
	class Program
	{

		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			var cs = "AaaaaaaBbbccaaaaaaaaaaaAAAAAAAa";
			//Problem one.
			var stringTechTest = new StringTextTechTest();
			stringTechTest.TechTestOne(cs);
			//problem number two;
			Console.WriteLine("Tech test number 2");
			var BTTTT2 = new BinaryTreeTechTest2();
			BTTTT2.TestTreeSolution();

			Console.WriteLine("Tech Test number 3");
			var premutationsTest = new PrenumtationsTest("ABC");

		}

	}
}
