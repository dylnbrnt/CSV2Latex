using System;

namespace CSV2Latex
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			LatexFormatter format = new LatexFormatter ();

			//try{
			//string filename = Console.ReadLine();
			format.Load ("lab4.csv");
			Console.WriteLine("Rows: "+format.RowCount.ToString() +" Coloumns: "+format.ColumnCount.ToString());
			Console.WriteLine(format.Header);
			//Console.ReadLine ();
			//}catch (Exception eFileMissing){
			//	Console.Error.WriteLine("Error loading file: {0}", eFileMissing.Message);
			//}
		}//end main
	}
}
