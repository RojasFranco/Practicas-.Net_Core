using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace curso.common.DTOs
{
	public class TableJSONv1
	{
		private List<string> _headers;
		private List<List<string>> _rows;

		public List<string> Headers { get => _headers; set => _headers = value; }
		public List<List<string>> Rows { get => _rows; set => _rows = value; }

		public TableJSONv1()
		{
			_headers = new List<string>();
			_rows = new List<List<string>>();
		}
	}
}