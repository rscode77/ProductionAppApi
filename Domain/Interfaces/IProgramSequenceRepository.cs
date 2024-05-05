using Domain.Entities;

namespace Domain.Interfaces
{
	public interface IProgramSequenceRepository
	{
		Task AddProgramSequence(MachineProgramSequence programSequence);

		Task UpdateProgramSequence(MachineProgramSequence programSequence);

		Task RemoveProgramSequence(Guid programSequenceId);
	}
}