using Domain.Entities;

namespace Domain.Interfaces
{
	public interface IProgramSequenceService
	{
		Task AddProgramSequence(MachineProgramSequence programSequence);

		Task UpdateProgramSequence(MachineProgramSequence programSequence);

		Task RemoveProgramSequence(Guid programSequenceId);
	}
}