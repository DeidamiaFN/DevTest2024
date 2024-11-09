using backend.Dtos;
using backend.Entities;

namespace backend.profiles;

public class OptionProfile : AutoMapper.Profile
{
  public OptionProfile()
  {
    CreateMap<Option, OptionsDto>();
    CreateMap<(OptionPostDto o, int id, int pollId, int votes), Option>()
      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
      .ForMember(dest => dest.PollId, opt => opt.MapFrom(src => src.pollId))
      .ForMember(dest => dest.Votes, opt => opt.MapFrom(src => src.votes))
      .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.o.Name));
  }
}