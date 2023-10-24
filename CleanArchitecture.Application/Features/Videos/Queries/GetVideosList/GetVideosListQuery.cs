using MediatR;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideosListQuery : IRequest<IList<VideoDto>>
    {
        public string Username { get; set; } = string.Empty;

        public GetVideosListQuery(string username)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}
