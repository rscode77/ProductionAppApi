using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
	public class LocationService : ILocationService
	{
		private readonly ILocationRepository _locationRepository;

		public LocationService(ILocationRepository locationRepository)
		{
			_locationRepository = locationRepository;
		}

		public async Task AddNewLocation(Location location)
		{
			await _locationRepository.AddNewLocation(location);
		}

		public async Task DeleteLocation(Guid id)
		{
			await _locationRepository.DeleteLocation(id);
		}

		public async Task<List<Location>> GetLocations()
		{
			return await _locationRepository.GetLocations();
		}

		public async Task UpdateLocation(Location location)
		{
			await _locationRepository.UpdateLocation(location);
		}
	}
}