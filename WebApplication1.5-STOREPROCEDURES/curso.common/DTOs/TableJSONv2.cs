using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using curso.common.Interfaces;

namespace curso.common.DTOs
{
	public class TableJSONv2
	{
		private List<string> _headers;
		private List<IRowneable> _data;

		public List<string> Headers { get => _headers;  }
		public List<List<string>> Rows { get {
				List<List<string>> rows = new List<List<string>>();
				foreach (IRowneable data in _data) {
					rows.Add(data.ToRow());
				}
				return rows;
			} }
		public List<IRowneable> Data { get => _data; set => _data = value; }

		public TableJSONv2()
		{
			_headers = new List<string>();
			_data = new List<IRowneable>();
		}
	}
}