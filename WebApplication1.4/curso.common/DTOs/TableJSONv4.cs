using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using curso.common.CustomAttributes;
using curso.common.Interfaces;

namespace curso.common.DTOs
{
	public class TableJSONv4<T>
	{
		private List<IRowneable> _data;

		public List<string> Headers
		{
			get
			{
				List<string> headers = new List<string>();
				var type = typeof(T);
				foreach (var property in type.GetProperties())
				{
					var propertyAttributes = Attribute.GetCustomAttributes(property);
					headers.Add(((HeaderNameAttribute)propertyAttributes[0]).Name);
				}
				return headers;
			}
		}
		public List<List<string>> Rows
		{
			get
			{
				List<List<string>> rows = new List<List<string>>();
				foreach (IRowneable data in _data)
				{
					rows.Add(data.ToRow());
				}
				return rows;
			}
		}
		public List<IRowneable> Data { get => _data; set => _data = value; }

		public TableJSONv4()
		{
			_data = new List<IRowneable>();
		}
	}
}