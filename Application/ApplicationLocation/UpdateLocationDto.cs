using Domain.Entities;

namespace Application.ApplicationLocation
{
	public class UpdateLocationDto
	{
		public LocationType Type { get; set; }
		public string Name { get; set; } = default!;
		public string Place { get; set; } = default!;
		public string AdditionalPlace { get; set; } = default!;
	}
}