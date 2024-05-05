namespace Domain.Entities
{
	public enum LocationType
	{
		Warehouse,
		Machine,
		Other
	}

	public class Location
	{
		public Guid Id { get; set; }
		public LocationType Type { get; set; }
		public string Name { get; set; } = default!;
		public string Place { get; set; } = default!;
		public string AdditionalPlace { get; set; } = default!;
	}
}