using Domain.Interfaces;
using Infrastructure.Persistance;

namespace Infrastructure.Helpers
{
	public class SqlDataLogger : IDataLogger
	{
		private readonly ProductionAppDbContext _dbContext;

		public SqlDataLogger(ProductionAppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task Log(Exception e, string message)
		{
			_dbContext.EventLogs.Add(
				new Domain.Entities.EventLogs { Exception = e.ToString(), Message = message }
			);

			await _dbContext.SaveChangesAsync();
		}
	}
}