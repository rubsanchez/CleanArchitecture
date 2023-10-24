using FluentValidation;

namespace CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandValidator : AbstractValidator<CreateStreamerCommand>
    {
        public CreateStreamerCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{Name} cannot be empty")
                .NotNull()
                .MaximumLength(50).WithMessage("{Name} must be max. 50 chracaters");

            RuleFor(x => x.Url)
                .NotEmpty().WithMessage("{Url} cannot be empty");
        }
    }
}
