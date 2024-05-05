namespace Domain.Entities
{
	public class MachineProgram
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string? Description { get; set; } = string.Empty;
		public string? Comments { get; set; } = string.Empty;
		public int? ProgramStatusId { get; set; }
		public virtual ProgramStatus? ProgramStatus { get; set; } = default!;
		public virtual ICollection<MachineProgramSequence> ProgramSequences { get; set; } = default!;
		public DateTime CreationDate { get; set; } = DateTime.Now;
		public DateTime? RealizationDate { get; set; }
		public int? Position { get; set; }
		public Guid? LocationId { get; set; }
		public virtual Location? Location { get; set; } = default!;
	}
}