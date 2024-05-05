using Domain.Entities;
namespace Domain.Interfaces
{
    public interface IMaterialRepository
    {
        public Task<List<Material>> GetMaterials();

        public Task<Material> GetMaterialById(Guid id);

        public Task<List<MaterialHistory>> GetMaterialHistory(Guid id);

        public Task AddMaterialPhoto(MaterialImage materialImage);

        public Task AddMaterialHistory(MaterialHistory history);

        public Task AddNewMaterial(Material waste);

        public Task UpdateMaterial(Material waste);

        public Task DeleteMaterial(Guid wasteId);
    }
}