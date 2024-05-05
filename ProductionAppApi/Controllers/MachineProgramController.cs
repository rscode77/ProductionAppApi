using Application.ApplicationMachineProgram;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProductionAppApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class MachineProgramController : ControllerBase
	{
		private readonly IMachineProgramService _machineProgramService;
		private readonly IMapper _mapper;

		public MachineProgramController(IMachineProgramService machineProgramService, IMapper mapper)
		{
			_machineProgramService = machineProgramService;
			_mapper = mapper;
		}

		[HttpPost("AddNewProgram")]
		public async Task<IActionResult> AddMachineProgram(AddMachineProgramDto machineProgramData)
		{
			await _machineProgramService.AddMachineProgram(_mapper.Map<MachineProgram>(machineProgramData));

			return Ok(new ServiceResponse<string> { Message = $"Program {machineProgramData.Name} added." });
		}

		[HttpDelete("RemoveProgram")]
		public async Task<IActionResult> DeleteMachineProgram(Guid programId)
		{
			await _machineProgramService.DeleteMachineProgram(programId);

			return Ok(new ServiceResponse<string> { Message = "Program removed." });
		}

		[HttpPut("UpdateProgram")]
		public async Task<IActionResult> UpdateMachineProgram(UpdateMachineProgramDto machineProgram)
		{
			await _machineProgramService.UdpateMachineProgram(_mapper.Map<MachineProgram>(machineProgram));

			return Ok(new ServiceResponse<string> { Message = "Program updated." });
		}
	}
}