using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
	public class ProductionAppDbContext : DbContext
	{
		public ProductionAppDbContext(DbContextOptions<ProductionAppDbContext> options)
			: base(options) { }

		public DbSet<Role> Roles { get; set; }
		public DbSet<UserProfiles> UserProfiles { get; set; }
		public DbSet<UserActivity> UserActivity { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Material> Materials { get; set; }
		public DbSet<MaterialImage> MaterialImages { get; set; }
		public DbSet<Location> Locations { get; set; }
		public DbSet<MaterialStatus> MaterialStatus { get; set; }
		public DbSet<MaterialHistory> MaterialHistories { get; set; }
		public DbSet<MaterialPlan> MaterialPlans { get; set; }
		public DbSet<MachineProgram> MachineProgram { get; set; }
		public DbSet<ProgramStatus> ProgramStatuses { get; set; }
		public DbSet<MachineProgramSequence> ProgramSequences { get; set; }
		public DbSet<EventLogs> EventLogs { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			foreach (
				var relationship in modelBuilder
					.Model.GetEntityTypes()
					.SelectMany(e => e.GetForeignKeys())
			)
			{
				relationship.DeleteBehavior = DeleteBehavior.Restrict;
			}

			modelBuilder.Entity<User>().HasOne(u => u.Role).WithMany().HasForeignKey(u => u.RoleId);

			modelBuilder
				.Entity<MachineProgram>()
				.HasOne(mp => mp.Location)
				.WithMany()
				.HasForeignKey(mp => mp.LocationId);

			modelBuilder
				.Entity<MachineProgramSequence>()
				.HasOne(p => p.ProgramStatus)
				.WithMany()
				.HasForeignKey(p => p.ProgramStatusId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder
				.Entity<UserActivity>()
				.HasOne(ua => ua.User)
				.WithOne(u => u.UserActivity)
				.HasForeignKey<UserActivity>(ua => ua.UserId);

			modelBuilder
				.Entity<User>()
				.HasOne(u => u.UserProfiles)
				.WithOne(up => up.User)
				.HasForeignKey<UserProfiles>(up => up.UserId);

			modelBuilder.Entity<User>(r =>
			{
				r.Property(u => u.Username).IsRequired();
				r.Property(u => u.Email).IsRequired();
				r.Property(u => u.Password).IsRequired();
			});

			modelBuilder
				.Entity<Material>()
				.HasOne(u => u.Status)
				.WithMany()
				.HasForeignKey(u => u.StatusId);

			modelBuilder
				.Entity<MaterialImage>()
				.HasOne(wi => wi.Material)
				.WithMany(w => w.MaterialImage)
				.HasForeignKey(wi => wi.MaterialId);
		}
	}
}