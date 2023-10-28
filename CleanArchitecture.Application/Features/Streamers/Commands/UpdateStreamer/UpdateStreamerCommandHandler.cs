using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandHandler : IRequestHandler<UpdateStreamerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ILogger<UpdateStreamerCommandHandler> _logger;

        public UpdateStreamerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateStreamerCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamer = await _unitOfWork.Repository<Streamer>().GetByIdAsync(request.Id);

            if (streamer == null)
            {
                _logger.LogError($"Streamer id {request.Id} could not be found");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }

            _mapper.Map<Streamer>(request);

            _unitOfWork.Repository<Streamer>().UpdateEntity(streamer);
            await _unitOfWork.Complete();

            _logger.LogInformation($"Streamer {request.Id} updated successfully");

            return Unit.Value;
        }
    }
}
