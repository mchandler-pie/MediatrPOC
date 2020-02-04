using System.Linq;
using FluentValidation;
using Packages.Pie.Pipeline.Messages;

namespace Packages.Validators
{
    public class QuoteRequestValidator : ValidatorBase<ValidateQuoteRequestCommand>
    {
        public QuoteRequestValidator()
        {
            RuleFor(pc => pc.InitialRequest.EffectiveDate)
                .NotEmpty()
                .WithMessage(ValidationLibrary.RequiredError)
                .Must(fn => !string.IsNullOrWhiteSpace(fn))
                .WithMessage(ValidationLibrary.RequiredError);

            RuleFor(pc => pc.InitialRequest.Contacts)
                .NotEmpty()
                .WithMessage(ValidationLibrary.RequiredError)
                .Must(fn => fn != null && fn.Any())
                .WithMessage(ValidationLibrary.RequiredError);

            RuleForEach(pr => pr.InitialRequest.Contacts)
                .SetValidator(new QuoteContactPostValidator())
                .When(pr => pr.InitialRequest.Contacts != null);
        }
    }
}
