using Application.ApplicationLocation;
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
	[Authorize(Roles = "Administrator")]
	public class LocationController : ControllerBase
	{
		private readonly ILocationService _locationService;
		private readonly IMapper _mapper;

		public LocationController(ILocationService locationService, IMapper mapper)
		{
			_locationService = locationService;
			_mapper = mapper;
		}

		[HttpPost("AddNewLocation")]
		public async Task<IActionResult> AddNewLocation(AddLocationDto location)
		{
			await _locationService.AddNewLocation(_mapper.Map<Location>(location));
			return Ok(new ServiceResponse<string> { Message = $"Location added." });
		}

		[HttpDelete("DeleteLocation")]
		public async Task<IActionResult> DeleteLocation(Guid id)
		{
			await _locationService.DeleteLocation(id);
			return Ok(new ServiceResponse<string> { Message = $"Location removed." });
		}

		[HttpPut("UpdateLocation")]
		public async Task<IActionResult> UpdateLocation(UpdateLocationDto location)
		{
			await _locationService.UpdateLocation(_mapper.Map<Location>(location));
			return Ok(new ServiceResponse<string> { Message = $"Location updated." });
		}

		[HttpGet("GetLocations")]
		[Authorize]
		public async Task<IActionResult> GetLocations()
		{
			var locations = await _locationService.GetLocations();

			return Ok(new ServiceResponse<List<Location>> { Data = locations });
		}
	}
}