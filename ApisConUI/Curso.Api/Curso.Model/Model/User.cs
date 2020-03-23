using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curso.Model.Model
{
	public class User
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(TypeName = "bigint")]
		public long Id { get; set; }

		[MaxLength(20)]
		[Required]
		public string UserName { get; set; }

		[MaxLength(50)]
		[Required]
		public string Password { get; set; }

		[DefaultValue(null)]
		public DateTime? LastLoginDate { get; set; }

		[MaxLength(50)]
		[Required]
		public string DefaultPage { get; set; }
	}
}

