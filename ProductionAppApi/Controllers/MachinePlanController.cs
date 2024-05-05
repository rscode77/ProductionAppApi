using Application.ApplicationMachinePlan;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductionAppApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class MachinePlanController : ControllerBase
	{
		private readonly IMachinePlanService _machinePlanService;
		private readonly IMapper _mapper;

		public MachinePlanController(IMachinePlanService machinePlanService, IMapper mapper)
		{
			_machinePlanService = machinePlanService;
			_mapper = mapper;
		}

		[HttpPost("GetMachinePlan")]
		public async Task<ActionResult<List<MachineProgram>>> GetMachinePlan(GetMachinePlanDto getMachinePlanDto)
		{
			var machinePlanDto = _mapper.Map<MachineProgram>(getMachinePlanDto);
			return Ok(new ServiceResponse<List<MachineProgram>> { Data = await _machinePlanService.GetMachinePlan(machinePlanDto) });
		}

		[HttpGet("GetMachines")]
		public async Task<ActionResult<List<Location>>> GetMachines()
		{
			return Ok(new ServiceResponse<List<Location>> { Data = await _machinePlanService.GetMachines() });
		}
	}
}