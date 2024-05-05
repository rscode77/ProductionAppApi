using Application.ApplicationAuth;
using Application.Interfaces;
using Application.Mapping;
using Application.Services;
using Application.Validators;
using AutoMapper;
using Domain.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
	public static class ServiceCollectionExtension
	{
		public static void AddApplication(this IServiceCollection services)
		{
			services.AddControllers().AddFluentValidation();

			services.AddScoped<IAuthService, AuthService>();
			services.AddScoped<IUserContextService, UserContextService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IMaterialService, MaterialService>();
			services.AddScoped<IMachinePlanService, MachinePlanService>();
			services.AddScoped<IDataLoggerService, DataLoggerService>();
			services.AddScoped<ILocationService, LocationService>();
			services.AddScoped<IMachineProgramService, MachineProgramService>();
			services.AddScoped<IProgramSequenceService, ProgramSequenceService>();

			AddFluentValidationServices(services);

			AddAutoMapper(services);
		}

		private static void AddFluentValidationServices(IServiceCollection services)
		{
			services.AddScoped<IValidator<RegisterDto>, RegisterDtoValidator>();
			services.AddScoped<IValidator<LoginDto>, LoginDtoValidator>();
		}

		private static void AddAutoMapper(IServiceCollection services)
		{
			services.AddScoped(provider =>
				new MapperConfiguration(cfg =>
				{
					cfg.AddProfile(new ProductionAppMappingProfile());
				}).CreateMapper()
			);
		}
	}
}