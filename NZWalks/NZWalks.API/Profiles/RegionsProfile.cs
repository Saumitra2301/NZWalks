using AutoMapper;

namespace NZWalks.API.Profiles
{
    public class RegionsProfile:Profile
    {
        public RegionsProfile()
        {
            CreateMap<Models.Domain.Region, Models.DTO.Region>()
                .ReverseMap();
            CreateMap<Models.Domain.Region, Models.DTO.AddRegionRequest>()
               .ReverseMap();
            CreateMap<Models.DTO.UpdateRegionRequest, Models.Domain.Region>();
               .ReverseMap();
        }
    }
}
