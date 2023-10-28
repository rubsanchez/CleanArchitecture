using FluentValidation;

namespace CleanArchitecture.Application.Features.Directors.Commands.CreateDirector
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("{Name} cannot be null");

            RuleFor(x => x.Surname)
                .NotNull().WithMessage("{Surname} cannot be null");
        }
    }
}
