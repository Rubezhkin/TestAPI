using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Models;

namespace Mappings;

public class AppMappingProfile : Profile
{
	public AppMappingProfile()
	{
		CreateMap<Dadata.Model.Address, Address>()
		.ForMember(dest => dest.FullAddress, opt => opt.MapFrom(src => src.result))
		.ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.postal_code))
		.ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.country))
		.ForMember(dest => dest.District, opt => opt.MapFrom(src => src.federal_district))
		.ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.region_with_type));
	}
}