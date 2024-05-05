using Domain.Interfaces;
using Infrastructure.Helpers;
using Infrastructure.Persistance;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
	public class DataLoggerService : IDataLoggerService
	{
		private readonly List<IDataLogger> _dataLoggers;

		private readonly ILogger<DataLoggerService> _logger;

		private readonly ProductionAppDbContext _dbContext;

		public DataLoggerService(ILogger<DataLoggerService> logger, ProductionAppDbContext dbContext)
		{
			_logger = logger;
			_dbContext = dbContext;

			var fileDataLogger = new FileDataLogger(_logger);
			var sqlDataLogger = new SqlDataLogger(_dbContext);

			_dataLoggers = new List<IDataLogger> { fileDataLogger, sqlDataLogger };
		}

		public async Task Log(Exception e, string message)
		{
			foreach (var dataLogger in _dataLoggers)
			{
				await dataLogger.Log(e, message);
			}
		}
	}
}