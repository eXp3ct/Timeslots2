using FluentValidation;
using MediatR;

namespace Expect.Timeslots.Infrastructure.Behaviors
{
    public class ValidationBehavior<TRequest, TResult>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResult>
        where TRequest : IRequest<TResult>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

        Task<TResult> IPipelineBehavior<TRequest, TResult>.Handle(TRequest request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var failures = _validators
                                .Select(v => v.Validate(context))
                                .SelectMany(v => v.Errors)
                                .Where(failure => failure != null)
                                .ToList();

            if (failures.Count != 0)
                throw new ValidationException(failures);

            return next();
        }
    }
}
