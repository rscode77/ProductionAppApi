namespace Domain.Entities
{
	public class MaterialHistory : Material
	{
		public DateTime OperationDate { get; } = DateTime.Now;
		public Guid UserId { get; set; }
		public User User { get; set; } = default!;
	}
}