using Application.ApplicationMachineProgram;
using Application.ApplicationProgramSequence;
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
	public class ProgramSequenceController : ControllerBase
	{
		private readonly IProgramSequenceService _programSequenceService;
		private readonly IMapper _mapper;

		public ProgramSequenceController(IProgramSequenceService programSequenceService, IMapper mapper)
		{
			_programSequenceService = programSequenceService;
			_mapper = mapper;
		}

		[HttpPost("AddProgramSequence")]
		public async Task<IActionResult> AddProgramSequence(AddProgramSequenceDto programSequence)
		{
			await _programSequenceService.AddProgramSequence(_mapper.Map<MachineProgramSequence>(programSequence));

			return Ok(new ServiceResponse<string> { Message = $"Added program sequence." });
		}

		[HttpPut("UpdateProgramSequence")]
		public async Task<IActionResult> UpdateProgramSequence(UpdateMachineProgramDto programSequence)
		{
			await _programSequenceService.UpdateProgramSequence(_mapper.Map<MachineProgramSequence>(programSequence));

			return Ok(new ServiceResponse<string> { Message = "Program sequence updated." });
		}

		[HttpDelete("DeleteProgramSequence")]
		public async Task<IActionResult> DeleteProgramSequence(Guid sequenceId)
		{
			await _programSequenceService.RemoveProgramSequence(sequenceId);

			return Ok(new ServiceResponse<string> { Message = "Program sequence deleted." });
		}
	}
}