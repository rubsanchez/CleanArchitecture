using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideosListQueryHandler : IRequestHandler<GetVideosListQuery, IList<VideoDto>>
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IMapper _mapper;

        public GetVideosListQueryHandler(IVideoRepository videoRepository, IMapper mapper)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;
        }

        public async Task<IList<VideoDto>> Handle(GetVideosListQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Video> videoList = await _videoRepository.GetVideoByUserName(request.Username);

            return _mapper.Map<IList<VideoDto>>(videoList);
        }
    }
}
