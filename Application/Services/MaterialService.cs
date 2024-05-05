using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialService(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }
        public async Task AddNewMaterial(Material material)
        {
            await _materialRepository.AddNewMaterial(material);
        }

        public async Task AddMaterialHistory(MaterialHistory history)
        {
            await _materialRepository.AddMaterialHistory(history);
        }

        public async Task AddMaterialPhoto(MaterialImage materialImage)
        {
            await _materialRepository.AddMaterialPhoto(materialImage);
        }

        public async Task DeleteMaterial(Guid materialId)
        {
            await _materialRepository.DeleteMaterial(materialId);
        }

        public async Task<Material> GetMaterialById(Guid id)
        {
            return await _materialRepository.GetMaterialById(id);
        }

        public async Task<List<MaterialHistory>> GetMaterialHistory(Guid id)
        {
            return await _materialRepository.GetMaterialHistory(id);
        }

        public async Task<List<Material>> GetMaterials()
        {
            return await _materialRepository.GetMaterials();
        }

        public async Task UpdateMaterial(Material waste)
        {
            await _materialRepository.UpdateMaterial(waste);
        }
    }
}
