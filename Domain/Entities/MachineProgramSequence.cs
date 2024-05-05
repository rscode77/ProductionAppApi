namespace Domain.Entities
{
	public class MachineProgramSequence
	{
		public Guid Id { get; set; }
		public string Description { get; set; } = string.Empty;
		public string Comments { get; set; } = string.Empty;
		public int X { get; set; }
		public int Y { get; set; }
		public int? Position { get; set; }
		public int Thickness { get; set; }
		public int RealizationTime { get; set; } = 0;
		public int SuggestedRealizationTime { get; set; }
		public int Start { get; set; }
		public int Stop { get; set; }
		public int? ProgramStatusId { get; set; }
		public virtual ProgramStatus? ProgramStatus { get; set; }
		public Guid MachineProgramId { get; set; }
		public virtual MachineProgram? MachineProgram { get; set; }
		public Guid UserId { get; set; }
		public virtual User? User { get; set; }
	}
}