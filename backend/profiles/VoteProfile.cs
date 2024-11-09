using backend.Dtos;
using backend.Entities;

namespace backend.profiles;

public class VoteProfile : AutoMapper.Profile
{
  public VoteProfile()
  {
    CreateMap<Vote, VoteResponseDto>();
    CreateMap<(VoteDto v, int id), Vote>()
      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
      .ForMember(dest => dest.voterEmail, opt => opt.MapFrom(src => src.v.voterEmail))
      .ForMember(dest => dest.pollId, opt => opt.MapFrom(src => src.v.pollId))
      .ForMember(dest => dest.optionId, opt => opt.MapFrom(src => src.v.optionId));

    CreateMap<(VoteNoPollDto v, int id), VoteDto>()
      .ForMember(dest => dest.voterEmail, opt => opt.MapFrom(src => src.v.voterEmail))
      .ForMember(dest => dest.pollId, opt => opt.MapFrom(src => src.id))
      .ForMember(dest => dest.optionId, opt => opt.MapFrom(src => src.v.optionID));
  }
}