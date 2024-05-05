using Domain.Entities;

namespace Domain.Interfaces
{
	public interface IMachinePlanService
	{
		public Task<List<MachineProgram>> GetMachinePlan(MachineProgram machinePlan);

		public Task<List<Location>> GetMachines();
	}
}