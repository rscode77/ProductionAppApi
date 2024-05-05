using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
	public class MachinePlanRepository : IMachinePlanRepository
	{
		private readonly ProductionAppDbContext _dbContext;

		public MachinePlanRepository(ProductionAppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<MachineProgram>> GetMachinePlan(MachineProgram getMachinePlanDto)
		{
			return await _dbContext.MachineProgram.Where(x => x.RealizationDate == getMachinePlanDto.RealizationDate &&
				x.LocationId == getMachinePlanDto.LocationId).ToListAsync();
		}

		public async Task<List<Location>> GetMachines()
		{
			return await _dbContext.Locations.Where(x => x.Type == LocationType.Machine).ToListAsync();
		}
	}
}