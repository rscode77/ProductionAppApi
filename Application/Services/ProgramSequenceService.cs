using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
	public class ProgramSequenceService : IProgramSequenceService
	{
		private readonly IProgramSequenceRepository _programSequenceRepository;

		public ProgramSequenceService(IProgramSequenceRepository programSequenceRepository)
		{
			_programSequenceRepository = programSequenceRepository;
		}

		public async Task AddProgramSequence(MachineProgramSequence programSequence)
		{
			await _programSequenceRepository.AddProgramSequence(programSequence);
		}

		public async Task RemoveProgramSequence(Guid programSequenceId)
		{
			await _programSequenceRepository.RemoveProgramSequence(programSequenceId);
		}

		public async Task UpdateProgramSequence(MachineProgramSequence programSequence)
		{
			await _programSequenceRepository.UpdateProgramSequence(programSequence);
		}
	}
}