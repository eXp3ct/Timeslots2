using Expect.Timeslots.Infrastructure.Common.Queries.Gates.AddGate;
using Expect.Timeslots.Infrastructure.Validation.DtoValidation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Timeslots.Infrastructure.Validation.RequestValidation
{
    public class AddGateRequestValidator : AbstractValidator<AddGateRequest>
    {
        public AddGateRequestValidator()
        {
            RuleFor(x => x.Dto).NotEmpty().NotNull().SetValidator(new GateDtoValidator());
        }
    }
}
