using Application.ApplicationMaterial;
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
	public class MaterialController : ControllerBase
	{
		private readonly IMaterialService _materialService;
		private readonly IMapper _mapper;

		public MaterialController(IMaterialService materialService, IMapper mapper)
		{
			_materialService = materialService;
			_mapper = mapper;
		}

		[HttpGet("GetMaterials")]
		public async Task<ActionResult<List<Material>>> GetMaterials()
		{
			return Ok(new ServiceResponse<List<Material>> { Data = await _materialService.GetMaterials() });
		}

		[HttpGet("GetMaterial")]
		public async Task<ActionResult<Material>> GetMaterialById(Guid id)
		{
			return Ok(new ServiceResponse<Material> { Data = await _materialService.GetMaterialById(id) });
		}

		[HttpGet("GetMaterialHistory")]
		public async Task<ActionResult<List<MaterialHistory>>> GetMaterialHistory(Guid id)
		{
			return Ok(new ServiceResponse<List<MaterialHistory>> { Data = await _materialService.GetMaterialHistory(id) });
		}

		[HttpPost("AddMaterialPhoto")]
		public async Task<IActionResult> AddMaterialPhoto([FromBody] MaterialImage materialImage)
		{
			await _materialService.AddMaterialPhoto(materialImage);

			return Ok(new ServiceResponse<Task> { Message = "Photo added." });
		}

		[HttpPost("AddMaterialHistory")]
		public async Task<IActionResult> AddMaterialHistory([FromBody] AddMaterialHistoryDto materialHistory)
		{
			var material = _mapper.Map<MaterialHistory>(materialHistory);

			await _materialService.AddMaterialHistory(material);

			return Ok(new ServiceResponse<Task> { Message = "History added." });
		}

		[HttpPost("AddNewMaterial")]
		public async Task<IActionResult> AddNewMaterial([FromBody] AddMaterialDto material)
		{
			var materialDto = _mapper.Map<Material>(material);

			await _materialService.AddNewMaterial(materialDto);

			return Ok(new ServiceResponse<Task> { Message = "Material added." });
		}

		[HttpPut("UpdateMaterial")]
		public async Task<IActionResult> UpdateMaterial([FromBody] AddMaterialDto material)
		{
			var materialDto = _mapper.Map<Material>(material);

			await _materialService.UpdateMaterial(materialDto);

			return Ok(new ServiceResponse<Task> { Message = "Material updated." });
		}

		[HttpDelete("DeleteMaterial")]
		public async Task<IActionResult> DeleteMaterial(Guid id)
		{
			await _materialService.DeleteMaterial(id);

			return Ok(new ServiceResponse<Task> { Message = "Material deleted." });
		}
	}
}