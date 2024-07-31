using Expect.Timeslots.Infrastructure.Common.Queries.Platforms.AddPlatform;
using Expect.Timeslots.Infrastructure.Validation.DtoValidation;
using FluentValidation;

namespace Expect.Timeslots.Infrastructure.Validation.RequestValidation
{
    public class AddPlatformRequestValidator : AbstractValidator<AddPlatformRequest>
    {
        public AddPlatformRequestValidator()
        {
            RuleFor(x => x.PlatformDto).NotEmpty().NotNull().SetValidator(new PlatformDtoValidator());
        }
    }
}
