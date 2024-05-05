using Domain.Entities;

namespace Domain.Interfaces
{
	public interface ILocationRepository
	{
		Task AddNewLocation(Location location);

		Task UpdateLocation(Location location);

		Task DeleteLocation(Guid id);

		Task<List<Location>> GetLocations();
	}
}