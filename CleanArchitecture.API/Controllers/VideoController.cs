using CleanArchitecture.Application.Features.Videos.Queries;
using CleanArchitecture.Application.Features.Videos.Queries.GetVideosList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VideoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{username}", Name = "GetVideo")]
        [ProducesResponseType(typeof(IEnumerable<VideoDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VideoDto>>> GetByUsername(string username)
        {
            var query = new GetVideosListQuery(username);

            var videos = await _mediator.Send(query);
            return Ok(videos);
        }
    }
}