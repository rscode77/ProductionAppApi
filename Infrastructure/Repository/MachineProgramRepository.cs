using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Exceptions;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
	public class MachineProgramRepository : IMachineProgramRepository
	{
		private readonly ProductionAppDbContext _dbContext;

		public MachineProgramRepository(ProductionAppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<MachineProgram> AddMachineProgram(MachineProgram machineProgram)
		{
			_dbContext.MachineProgram.Add(machineProgram);

			await _dbContext.SaveChangesAsync();

			return machineProgram;
		}

		public async Task DeleteMachineProgram(Guid id)
		{
			var program = await _dbContext.MachineProgram.FirstOrDefaultAsync(x => x.Id == id);

			if (program == null)
				throw new NotFoundException("Program not found.");

			_dbContext.MachineProgram.Remove(program);

			await _dbContext.SaveChangesAsync();
		}

		public async Task UdpateMachineProgram(MachineProgram machineProgram)
		{
			var program = await _dbContext.MachineProgram.FirstOrDefaultAsync(x => x.Id == machineProgram.Id);

			if (program == null)
				throw new NotFoundException("Program not found.");

			_dbContext.MachineProgram.Remove(program);

			await _dbContext.SaveChangesAsync();
		}
	}
}