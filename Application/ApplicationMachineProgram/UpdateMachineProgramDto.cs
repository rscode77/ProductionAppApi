namespace Application.ApplicationMachineProgram
{
	public class UpdateMachineProgramDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string? Description { get; set; } = string.Empty;
		public string? Comments { get; set; } = string.Empty;
		public int? ProgramStatusId { get; set; }
		public DateTime? RealizationDate { get; set; }
		public int? Position { get; set; }
		public int? LocationId { get; set; }
	}
}