using FluentValidation;

namespace CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandValidator : AbstractValidator<UpdateStreamerCommand>
    {
        public UpdateStreamerCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("{Name} cannot be null")
                .NotEmpty();

            RuleFor(x => x.Url)
                .NotNull().WithMessage("{Url} cannot be null")
                .NotEmpty();
        }
    }
}
