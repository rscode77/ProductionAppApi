using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
	public class MachineProgramService : IMachineProgramService
	{
		private readonly IMachineProgramRepository _machineProgramRepository;

		public MachineProgramService(IMachineProgramRepository machineProgramRepository)
		{
			_machineProgramRepository = machineProgramRepository;
		}

		public async Task<MachineProgram> AddMachineProgram(MachineProgram machineProgram)
		{
			var program = await _machineProgramRepository.AddMachineProgram(machineProgram);

			return program;
		}

		public async Task DeleteMachineProgram(Guid id)
		{
			await _machineProgramRepository.DeleteMachineProgram(id);
		}

		public async Task UdpateMachineProgram(MachineProgram machineProgram)
		{
			await _machineProgramRepository.UdpateMachineProgram(machineProgram);
		}
	}
}