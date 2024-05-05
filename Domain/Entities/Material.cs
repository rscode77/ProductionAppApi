namespace Domain.Entities
{
	public class Material
	{
		public Guid Id { get; set; }
		public int Length { get; set; }
		public int Width { get; set; }
		public double Thickness { get; set; }
		public string MaterialGrade { get; set; } = default!;
		public int Quantity { get; set; }
		public int StatusId { get; set; }
		public virtual MaterialStatus? Status { get; set; } = default!;
		public DateTime StatusDate { get; } = DateTime.Now;
		public Guid? LocationId { get; set; }
		public virtual Location? Location { get; set; } = default!;
		public virtual List<MaterialImage>? MaterialImage { get; set; } = default!;
	}
}