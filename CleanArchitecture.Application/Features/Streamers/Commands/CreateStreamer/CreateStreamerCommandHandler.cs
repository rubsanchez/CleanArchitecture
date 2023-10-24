using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
    {
        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateStreamerCommandHandler> _logger;

        public CreateStreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper, IEmailService emailService, ILogger<CreateStreamerCommandHandler> logger)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerEntity = _mapper.Map<Streamer>(request);
            var newStreamer = await _streamerRepository.AddAsync(streamerEntity);

            _logger.LogInformation($"Streamer {newStreamer.Id} created succesfully");

            await SendEmail(newStreamer);

            return newStreamer.Id;
        }

        private async Task SendEmail(Streamer streamer)
        {
            try
            {
                Email email = new()
                {
                    To = "rubsanchez@outlook.es",
                    Body = $"Streamer company {streamer.Name} created successfully",
                    Subject = "Alert message"
                };

                await _emailService.SendEmailAsync(email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errors sending mail of {streamer.Id}");
            }
        }
    }
}
