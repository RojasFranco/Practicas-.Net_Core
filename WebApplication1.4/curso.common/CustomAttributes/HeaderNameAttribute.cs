using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace curso.common.CustomAttributes
{
	[AttributeUsage(AttributeTargets.All | AttributeTargets.Constructor | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
	public class HeaderNameAttribute : Attribute
	{
		private string name;

		public HeaderNameAttribute(string name)
		{
			this.name = name;
		}

		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}
	}
}