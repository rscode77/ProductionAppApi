namespace Application.ApplicationProgramSequence
{
	public class AddProgramSequenceDto
	{
		public string Description { get; set; } = string.Empty;
		public string Comments { get; set; } = string.Empty;
		public int X { get; set; }
		public int Y { get; set; }
		public int Thickness { get; set; }
		public int RealizationTime { get; set; } = 0;
		public int SuggestedRealizationTime { get; set; }
		public int MachineProgramId { get; set; }
		public Guid UserId { get; set; }
	}
}