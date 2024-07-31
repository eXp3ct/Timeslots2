using Expect.Timeslots.Domain.Dtos;
using FluentValidation;

namespace Expect.Timeslots.Infrastructure.Validation.DtoValidation
{
    public class GateDtoValidator : AbstractValidator<GateDto>
    {
        public GateDtoValidator()
        {
            RuleFor(x => x.PlatformId).NotEmpty().NotNull();
            RuleFor(x => x.Number).NotEmpty().NotNull().GreaterThanOrEqualTo(1);
        }
    }
}
