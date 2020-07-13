using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GyL.DDD.DotNet.Domain.Model
{
	public class Sample
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(TypeName = "bigint")]
		public long Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string Description { get; set; }
	}
}
