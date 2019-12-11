using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Adam Moffat
//Wheel Right Technical Test
//11/12/19
//The purpose of this exercise is to allow the demonstration of your ability to analyse a set of task requirements, design a solution that meets the requirements and code the application in a manner appropriate to a professional engineer.
//Scenario
//A system has been developed to measure the temperature of vehicle tyres.The system consists of two temperature sensors that are placed in the centre of the road pointing at 180⁰ to each other.One of the sensors points left and the other points right so that both sides of the road are monitored.  The sensors start sampling when it is detected that a vehicle is approaching the system.The vehicle drives over the sensors so that each tyre may be recorded.Samples are recorded at a set frequency until the vehicle has fully passed over the sensors and is no longer detected.Due to the nature of real world systems these data samples may contain glitches in the data. 
//Task details
//The task is to produce an application that will analyse a file of temperature data, then calculate and report the following information from the data: 
	//1. Ambient temperature (one value per sensor) 
	//2. Maximum tyre temperatures (one value for each tyre detected)
	//3. Average tyre temperature (one value for each tyre detected) The user should be able to specify the file from which the data will be read.   
//Guidance for the Exercise
//a) An example data file is supplied with the exercise containing a series of temperature readings. In this file the results are reported in degrees Celsius. 
//	b) The data is from real sensors and might contain spikes / glitches that should be removed / ignored. 
//	c) The application should allow the file input to be specified and the results to be reported.  This can be done by either implementing a simple GUI or via a shell based application. 
//	d) We are looking for how you design and implement the solution, structure your code, handle and test for exceptions. e) The programming language used should be C#. 
//	f) Your source code, compiled executable and project (e.g. Visual Studio project) should form your answer.  Once completed your answer should be compressed and sent by email.   
//	g) There is no restriction on the time that can be spent on the task. h) If you have made any assumptions please let us know what they are.



namespace AdamMoffatTechnicalTest
{
	class WheelTechnicalTest
	{
		public List<int> LeftSide { get; set; }
		public List<int> RightSide { get; set; }
		int MaxTemp { get; set; }
		double AverageAmbientTemp { get; set; }
		double AverageOnRoadTemp { get; set; }

		public WheelTechnicalTest()
		{
			LeftSide = new List<int>();
			RightSide = new List<int>();
		}

		public List<string> FileStrings()
		{
			var strings = new List<string>();
			try
			{
				string address;
				string[] lines;
				Console.WriteLine("Please enter text file location: ");
				address = Console.ReadLine();

				if(address == null)
				{
					lines = System.IO.File.ReadAllLines(@"C:\Tyre Temperatures.txt");
				}
				else
				{
					lines = System.IO.File.ReadAllLines(address);
				}

				foreach(var line in lines)
				{
					strings.Add(line);
				}
				return strings;
			}
			catch
			{
				return strings;
			}
		}

		//sadly it's not a joke!! ha ha....no!
		public void SideSplitter(List<string> strings)
		{
			//started at element 1 to skip error with none int text;
			for(int i=1; i< strings.Count(); i++)
			{
				string firstValue = strings[i].Split('\t').First();
				string lastValue = strings[i].Split('\t').Last();
				LeftSide.Add(Int32.Parse(firstValue));
				RightSide.Add(Int32.Parse(lastValue));
			}
		}

		public double AverageAmbientTemperature(List<int> side)
		{
			var firstTemp = side.First();
			var tempList = new List<int>();
			foreach(var item in side)
			{
				if(firstTemp < item +1 || firstTemp > item -1)
				{
					tempList.Add(item);
				}
			}
			return tempList.Average();
		}

		public void OnRoadTempCalculation(List<int> side)
		{

			AverageAmbientTemp = AverageAmbientTemperature(side);
			var onRoadTemperates = new List<int>();


			foreach(var temp in side)
			{
				if(temp > AverageAmbientTemp)
				{
					onRoadTemperates.Add(temp);
				}
			}

			MaxTemp = onRoadTemperates.Max();
			AverageOnRoadTemp = onRoadTemperates.Average();

			
			
			Console.WriteLine($"Average Temperate: " + AverageAmbientTemp.ToString());
			Console.WriteLine($"Rounded Average Temp: " + Math.Round(AverageAmbientTemp, 2).ToString());
			Console.WriteLine($"Max on Road Temp: " + MaxTemp.ToString());
			Console.WriteLine($"Average On Road Temp: " + AverageOnRoadTemp.ToString());
			Console.WriteLine($"Rounded Average on Road Temp: " + Math.Round(AverageOnRoadTemp, 2).ToString());


		}






	}
}
