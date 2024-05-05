using Domain.Entities;

namespace Domain.Interfaces
{
	public interface IMachinePlanRepository
	{
		public Task<List<MachineProgram>> GetMachinePlan(MachineProgram getMachinePlanDto);

		public Task<List<Location>> GetMachines();
	}
}