using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Exceptions;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
	public class ProgramSequenceRepository : IProgramSequenceRepository
	{
		private readonly ProductionAppDbContext _dbContext;

		public ProgramSequenceRepository(ProductionAppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddProgramSequence(MachineProgramSequence programSequence)
		{
			_dbContext.ProgramSequences.Add(programSequence);

			await _dbContext.SaveChangesAsync();
		}

		public async Task RemoveProgramSequence(Guid sequenceId)
		{
			var programSequence = await _dbContext.ProgramSequences.FirstOrDefaultAsync(x =>
				x.Id == sequenceId
			);

			if (programSequence == null)
				throw new NotFoundException("Program sequence not found.");

			_dbContext.ProgramSequences.Remove(programSequence);

			await _dbContext.SaveChangesAsync();
		}

		public async Task UpdateProgramSequence(MachineProgramSequence programSequenceData)
		{
			var programSequence = await _dbContext.ProgramSequences.FirstOrDefaultAsync(x =>
				x.Id == programSequenceData.Id
			);

			if (programSequence == null)
				throw new NotFoundException("Program sequence not found.");

			programSequence = programSequenceData;

			await _dbContext.SaveChangesAsync();
		}
	}
}