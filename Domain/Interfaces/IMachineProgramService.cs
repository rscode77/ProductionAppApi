using Domain.Entities;

namespace Domain.Interfaces
{
	public interface IMachineProgramService
	{
		Task<MachineProgram> AddMachineProgram(MachineProgram machineProgram);

		Task UdpateMachineProgram(MachineProgram machineProgram);

		Task DeleteMachineProgram(Guid id);
	}
}