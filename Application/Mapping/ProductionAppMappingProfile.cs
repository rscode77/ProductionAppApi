using Application.ApplicationAuth;
using Application.ApplicationLocation;
using Application.ApplicationMachineProgram;
using Application.ApplicationMaterial;
using Application.ApplicationUser;
using ApplicationUser.User;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
	public class ProductionAppMappingProfile : Profile
	{
		public ProductionAppMappingProfile()
		{
			CreateMap<User, UserDto>().ReverseMap();
			CreateMap<LoginDto, User>();
			CreateMap<RegisterDto, User>();
			CreateMap<AddMaterialDto, Material>();
			CreateMap<AddMaterialHistoryDto, Material>();
			CreateMap<AddMaterialHistoryDto, MaterialHistory>();
			CreateMap<MaterialHistory, Material>();
			CreateMap<AddMaterialHistoryDto, AddMaterialDto>();
			CreateMap<ActivateAccountDto, User>();
			CreateMap<UpdateLocationDto, Location>();
			CreateMap<AddLocationDto, Location>();
			CreateMap<AddMachineProgramDto, MachineProgram>();

			CreateMap<UpdateUserDto, User>()
				.ForMember(
					dest => dest.UserProfiles,
					opt => opt.MapFrom(src => new UserProfiles { AvatarUrl = src.AvatarUrl })
				);

			CreateMap<User, User>()
				.ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
		}
	}
}