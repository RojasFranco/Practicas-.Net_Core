using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using curso.common.CustomAttributes;
using curso.common.Interfaces;

namespace curso.common.DTOs
{
	public class TableJSONv3
	{
		private List<IRowneable> _data;
		private Type _type;

		public List<string> Headers { get {

				List<string> headers = new List<string>();
				//var type = typeof(PersonaV3);
				foreach (var property in _type.GetProperties())
				{
					var propertyAttributes = Attribute.GetCustomAttributes(property);
					if (propertyAttributes.Length>0)
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

		[System.Xml.Serialization.XmlIgnore]
		public List<IRowneable> Data { get => _data; set => _data = value; }

		public TableJSONv3(Type type)
		{
			_data = new List<IRowneable>();
			_type = type;
		}
	}
}