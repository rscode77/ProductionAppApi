using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Exceptions;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
	public class LocationRepository : ILocationRepository
	{
		private readonly ProductionAppDbContext _dbContext;

		public LocationRepository(ProductionAppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddNewLocation(Location location)
		{
			_dbContext.Locations.Add(location);

			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteLocation(Guid id)
		{
			var location = await _dbContext.Locations.FirstOrDefaultAsync(x => x.Id == id);

			if (location == null)
				throw new NotFoundException("Location not found");

			_dbContext.Locations.Remove(location);

			await _dbContext.SaveChangesAsync();
		}

		public async Task<List<Location>> GetLocations()
		{
			return await _dbContext.Locations.ToListAsync();
		}

		public async Task UpdateLocation(Location locationData)
		{
			var location = await _dbContext.Locations.FirstOrDefaultAsync(x => x.Id == locationData.Id);

			if (location == null)
				throw new NotFoundException("Location not found");

			if (location.Name != locationData.Name)
				location.Name = locationData.Name;

			if (location.AdditionalPlace != locationData.AdditionalPlace)
				location.AdditionalPlace = locationData.AdditionalPlace;

			if (location.Place != locationData.Place)
				location.Place = locationData.Place;

			if (location.Type != locationData.Type)
				location.Type = locationData.Type;

			await _dbContext.SaveChangesAsync();
		}
	}
}