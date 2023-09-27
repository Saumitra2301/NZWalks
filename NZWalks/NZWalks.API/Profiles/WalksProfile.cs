using AutoMapper;

namespace NZWalks.API.Profiles
{
    public class WalksProfile:Profile
    {
        public WalksProfile() {
         CreateMap<Models.Domain.Walk,Models.DTO.Walk>().ReverseMap();
         CreateMap<Models.Domain.WalkDifficulty, Models.DTO.WalkDifficulty>().ReverseMap();
         CreateMap<Models.DTO.AddWalkRequest, Models.Domain.Walk>().ReverseMap();
         CreateMap<Models.DTO.AddWalkDifficultyRequest, Models.Domain.WalkDifficulty>().ReverseMap();
         CreateMap<Models.DTO.UpdateWalkDifficultyRequest, Models.Domain.WalkDifficulty>().ReverseMap();
        }
    }
}
