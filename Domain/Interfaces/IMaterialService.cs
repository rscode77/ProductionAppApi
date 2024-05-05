using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMaterialService
    {
        public Task<List<Material>> GetMaterials();

        public Task<Material> GetMaterialById(Guid id);

        public Task<List<MaterialHistory>> GetMaterialHistory(Guid id);

        public Task AddMaterialPhoto(MaterialImage materialImage);

        public Task AddMaterialHistory(MaterialHistory history);

        public Task AddNewMaterial(Material material);

        public Task UpdateMaterial(Material material);

        public Task DeleteMaterial(Guid materialId);
    }
}
