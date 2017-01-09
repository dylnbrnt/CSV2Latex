using System;

/**
 * [...]
 
 *
 * @author  Dylan Brunet
 * @version 2.0, 26/11/16
 */
namespace CSV2Latex
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("CSV to Latex Table Formatter v2.1\nSaves to file and clipboard!");
			Console.WriteLine("By Dylan Brunet\n");
			Console.WriteLine("Provide path to csv file to process,\noutput .txt file will be placed in same location\n\n");


			while(true)
			{
				Console.Write("File: ");

				LatexFormatter format = new LatexFormatter();
				try
				{
					string filename = Console.ReadLine();
					format.Load(filename);
					//format name of output file to save
					string[] temp = filename.Split('.');
					string outFilename = temp[0] + ".txt";
					//Save to file
					format.Save(outFilename);
					Console.WriteLine("Output complete!");
				}
				catch (Exception eFileMissing)
				{
					Console.Error.WriteLine("Error loading file: {0}", eFileMissing.Message);
				}
			}
		}//end main
	}
}
