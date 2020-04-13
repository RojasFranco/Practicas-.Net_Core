using System;
using System.Collections.Generic;
using System.Text;

namespace Curso.Common.DTO
{
	public class ResultJson
	{
		private string _message;
		private Guid? _tokenActualizado;
		public string Message { get => _message; set => _message = value; }
		public Guid? TokenActualizado { get => _tokenActualizado; set => _tokenActualizado = value; }
	}
}
