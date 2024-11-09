using backend.Dtos;
using backend.Entities;

namespace backend.profiles;

public class PollProfile : AutoMapper.Profile
{
  public PollProfile()
  {
    CreateMap<Poll, PollDto>();
    CreateMap<(PollPostDto p, int id), Poll>()
      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
      .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.p.Name));
    
    CreateMap<(string p, int id), Poll>()
      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
      .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.p));

    CreateMap<(Poll p, List<Option> l), PollResponseDto>()
      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.p.Id))
      .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.p.Name))
      .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.l));
  }
}