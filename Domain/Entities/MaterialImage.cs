using System.Text.Json.Serialization;

namespace Domain.Entities
{
	public class MaterialImage
	{
		public int Id { get; set; }
		public byte[] Image { get; set; } = default!;
		public DateTime CreationDate { get; set; }
		public Guid MaterialId { get; set; }

		[JsonIgnore]
		public Material Material { get; set; } = default!;
	}
}