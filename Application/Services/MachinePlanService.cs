using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class MachinePlanService : IMachinePlanService
    {
        private readonly IMachinePlanRepository _machinePlanRepository;

        public MachinePlanService(IMachinePlanRepository machinePlanRepository)
        {
            _machinePlanRepository = machinePlanRepository;
        }

        public async Task<List<MachineProgram>> GetMachinePlan(MachineProgram machinePlan)
        {
            return await _machinePlanRepository.GetMachinePlan(machinePlan);
        }

        public async Task<List<Location>> GetMachines()
        {
            return await _machinePlanRepository.GetMachines();
        }
    }
}
