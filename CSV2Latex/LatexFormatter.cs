using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;


namespace CSV2Latex
{
	public class LatexFormatter
	{
		private List<string> _inputData = new List<string>();
		private int _rowCount;
		private int _columnCount;
		private string _header = null;
		private string _values;

		public LatexFormatter ()
		{
		}

		/// <summary>
		/// Load the specified filename.
		/// </summary>
		/// <param name="filename">Filename.</param>
		public void Load(string filename)
		{
			StreamReader reader = new StreamReader (filename);
			try{				
				string input;
				while((input = reader.ReadLine()) != null) //whiles theres text to read
				{
					_inputData.Add(input);
				}
				//get the row count
				_rowCount = _inputData.Count;
				Process();

			}finally{
				reader.Close ();
			}
		}

		/// <summary>
		/// Process the csv data into Lastex table format
		/// </summary>
		public void Process(){
			//header
			string[] headerInput = _inputData[0].Split(',');
			_columnCount=0;
			//analyse for ,,,,
			foreach(string s in headerInput)
			{

				if(s == ""){
					break;
				}

				_columnCount++;
			}

			//process the header
			_header = "\\hline" + "\n";

			string[] _headerOutput = new string[_columnCount];
			//copy the contents over to the output header

			for(int j=0; j < _columnCount; j++)
			{
				_header += headerInput [j] + "\n"+ "& ";;
			}
			//format the end of the string
			_header = _header.Remove(_header.Length - 2, 2) +"\\\\\n\\hline";

			//process the values
			string[] valueInput;
			//go through each row

			for(int index = 1; index < _rowCount; index++)
			{
				valueInput = _inputData [index].Split (',');
				//	//add Latex table formatting
				for (int j = 0; j < _columnCount; j++)
				{
					if (j == _columnCount - 1)
					{
						//end of line
						_values += valueInput[j] + "\t\\\\\n\\hline\n";
					}
					else
					_values += valueInput[j] + " & ";
				}
			}

		}

		/// <summary>
		/// Save the specified filename.
		/// </summary>
		/// <param name="filename">Filename.</param>
		public void Save(string filename)
		{
			string Output = Header + Values;
			StreamWriter writer = new StreamWriter(filename);
			try
			{
				writer.WriteLine(Output);
			}
			finally
			{
				writer.Close();
			}
			SaveToClipboard(Output);
		}

		public void SaveToClipboard(string output)
		{
			Thread thread = new Thread(() => Clipboard.SetText(output));
			thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
			thread.Start();
			thread.Join();
		}

		public int RowCount{ get { return _rowCount; } }
		public int ColumnCount{ get { return  _columnCount; } }
		public List<string> InputData{ get { return _inputData; } }

		public string Header{ get { return _header; } }
		public string Values{ get { return _values; } }
	}
}

