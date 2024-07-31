using Expect.Timeslots.Domain.Dtos;
using FluentValidation;

namespace Expect.Timeslots.Infrastructure.Validation.DtoValidation
{
    public class PlatformDtoValidator : AbstractValidator<PlatformDto>
    {
        public PlatformDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(100);
        }
    }
}
