using AutoMapper;
using CleanArchitecture.Application.Features.Videos.Queries;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Video, VideoDto>();

            CreateMap<CreateStreamerCommand, Streamer>();
        }
    }
}
