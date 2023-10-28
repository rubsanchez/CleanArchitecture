using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandHandler : IRequestHandler<DeleteStreamerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ILogger<DeleteStreamerCommandHandler> _logger;

        public DeleteStreamerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteStreamerCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamer = _unitOfWork.Repository<Streamer>().GetByIdAsync(request.Id);

            if (streamer == null)
            {
                _logger.LogInformation($"Streamer {request.Id} could not be found");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }

            _unitOfWork.Repository<Streamer>().DeleteEntity(request.Id);
            await _unitOfWork.Complete();

            _logger.LogInformation($"Streamer {request.Id} deleted successfully");

            return Unit.Value;
        }
    }
}
