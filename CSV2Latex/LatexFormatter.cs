using System;
using System.IO;
using System.Collections.Generic;

namespace CSV2Latex
{
	public class LatexFormatter
	{
		private List<string> _inputData = new List<string>();
		private int _rowCount;
		private int _columnCount;
		private string _header = null;
		private string[] _values;

		public LatexFormatter ()
		{
		}

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
			_header = _header.Remove(_header.Length - 2, 2) +"\\\\";

			//process the values
			string[] valueInput;
			//go through each row
			for(int index = 1; index < _rowCount; index++)
			{
				valueInput = _inputData [index].Split (',');				
			}

		}

		public void ProcessValues()
		{

		}


		public int RowCount{ get { return _rowCount; } }
		public int ColumnCount{ get { return  _columnCount; } }
		public List<string> InputData{ get { return _inputData; } }

		public string Header{ get { return _header; } }
		public string[] Values{ get { return _values; } }
	}
}

