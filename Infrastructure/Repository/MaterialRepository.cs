using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Exceptions;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
	public class MaterialRepository : IMaterialRepository
	{
		private readonly ProductionAppDbContext _dbContext;

		public MaterialRepository(ProductionAppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddNewMaterial(Material material)
		{
			_dbContext.Materials.Add(material);
			await _dbContext.SaveChangesAsync();
		}

		public async Task AddMaterialHistory(MaterialHistory history)
		{
			_dbContext.MaterialHistories.Add(history);
			await _dbContext.SaveChangesAsync();
		}

		public async Task AddMaterialPhoto(MaterialImage materialImage)
		{
			_dbContext.MaterialImages.Add(materialImage);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteMaterial(Guid materialId)
		{
			var material = _dbContext.Materials.FirstOrDefault(x => x.Id == materialId);

			if (material == null)
				throw new NotFoundException("Material not found");

			_dbContext.Materials.Remove(material);

			await _dbContext.SaveChangesAsync();
		}

		public async Task<Material> GetMaterialById(Guid materialId)
		{
			var material = await _dbContext.Materials.FirstOrDefaultAsync(x => x.Id == materialId);

			if (material == null)
				throw new NotFoundException("Material not found");

			return material;
		}

		public async Task<List<MaterialHistory>> GetMaterialHistory(Guid id)
		{
			var materialHistory = await _dbContext.MaterialHistories.Where(x => x.Id == id).ToListAsync();

			return materialHistory;
		}

		public async Task<List<Material>> GetMaterials()
		{
			var materialHistory = await _dbContext.Materials.ToListAsync();

			return materialHistory;
		}

		public async Task UpdateMaterial(Material material)
		{
			var selectedMaterial = await _dbContext.Materials.FirstOrDefaultAsync(x => x.Id == material.Id);

			if (selectedMaterial == null)
				throw new NotFoundException("Material not found");

			_dbContext.Materials.Update(material);

			await _dbContext.SaveChangesAsync();
		}
	}
}