namespace Application.ApplicationLocation
{
	public class AddLocationDto
	{
		public int Type { get; set; }
		public string Name { get; set; } = default!;
		public string Place { get; set; } = default!;
		public string AdditionalPlace { get; set; } = default!;
	}
}