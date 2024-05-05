namespace Domain.Entities
{
	public class MaterialPlan
	{
		public Guid Id { get; set; }
		public Guid MaterialId { get; set; }
		public Material Material { get; set; } = default!;
		public int Quantity { get; set; }
		public DateTime PlanDate { get; set; }
		public Guid LocationId { get; set; }
		public virtual Location Location { get; set; } = default!;
		public string Name { get; set; } = default!;
		public Guid MachineProgramId { get; set; } = default!;
		public virtual MachineProgram MachineProgram { get; set; } = default!;
		public string Description { get; set; } = default!;
		public int Position { get; set; }
	}
}