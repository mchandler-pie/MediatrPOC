using FluentValidation;
using Packages.Pie.Pipeline.Messages;

namespace Packages.Validators
{
    public class QuoteRequestValidator : ValidatorBase<ValidateQuoteRequestCommand>
    {
        public QuoteRequestValidator()
        {
            RuleForEach(pr => pr.InitialRequest.Contacts)
                .SetValidator(new QuoteContactPostValidator())
                .When(pr => pr.InitialRequest.Contacts != null);
        }
    }
}
