using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curso.Model.Model
{
	public class Person
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None), Column(TypeName = "bigint")]
		public long DNI { get; set; }

		[MaxLength(50)]
		[Required]
		public string Name { get; set; }

		[MaxLength(50)]
		[Required]
		public string SurName { get; set; }
	}
}
