﻿using Domain.Interfaces;
using Infrastructure.Authorization;
using Infrastructure.Middleware;
using Infrastructure.Persistance;
using Infrastructure.Repository;
using Infrastructure.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProductionAppApi;
using System.Text;

namespace Infrastructure.Extensions
{
	public static class ServiceCollectionExtension
	{
		public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			AddJwtAuthentication(services, configuration);
			services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementHandler>();

			services.AddScoped<IAuthRepository, AuthRepository>();
			services.AddScoped<IPasswordHasher, PasswordHasher>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IMaterialRepository, MaterialRepository>();
			services.AddScoped<IMachinePlanRepository, MachinePlanRepository>();
			services.AddScoped<ILocationRepository, LocationRepository>();
			services.AddScoped<IMachineProgramRepository, MachineProgramRepository>();
			services.AddScoped<IProgramSequenceRepository, ProgramSequenceRepository>();

			services.AddScoped<ErrorHandlingMiddleware>();

			services.AddDbContext<ProductionAppDbContext>(options =>
				options.UseSqlServer(
					configuration.GetConnectionString("ProductionMaterialDb"),
					sqlServerOptions => sqlServerOptions.MigrationsAssembly("ProductionMaterialApi")
				)
			);
		}

		private static void AddJwtAuthentication(IServiceCollection services, IConfiguration configuration)
		{
			var authenticationSettings = new AuthenticationSettings();
			configuration.GetSection("Authentication").Bind(authenticationSettings);

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = "Bearer";
				options.DefaultChallengeScheme = "Bearer";
				options.DefaultChallengeScheme = "Bearer";
			}).AddJwtBearer(cfg =>
			{
				cfg.RequireHttpsMetadata = false;
				cfg.SaveToken = true;
				cfg.TokenValidationParameters = new TokenValidationParameters
				{
					ValidIssuer = authenticationSettings.JwtIssuer,
					ValidAudience = authenticationSettings.JwtIssuer,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
				};
			});
			services.AddSingleton(authenticationSettings);
		}
	}
}