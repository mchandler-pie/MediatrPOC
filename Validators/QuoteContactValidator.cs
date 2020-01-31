using FluentValidation;
using MediatrPOC.Messages;

namespace MediatrPOC.Validators
{
	public class QuoteContactPostValidator : ValidatorBase<ValidateQuoteRequestCommand>
	{
		public QuoteContactPostValidator()
		{
			RuleFor(pc => pc.request.FirstName)
				.NotEmpty()
				.WithMessage(ValidationLibrary.RequiredError)
				.Must(fn => !string.IsNullOrWhiteSpace(fn))
				.WithMessage(ValidationLibrary.RequiredError);

			RuleFor(pc => pc.request.LastName)
				.NotEmpty()
				.WithMessage(ValidationLibrary.RequiredError)
				.Must(ln => !string.IsNullOrWhiteSpace(ln))
				.WithMessage(ValidationLibrary.RequiredError);

			RuleFor(pc => pc.request.Email)
				.NotEmpty()
				.WithMessage(ValidationLibrary.RequiredError)
				.Must(e => !string.IsNullOrWhiteSpace(e))
				.WithMessage(ValidationLibrary.RequiredError);

            RuleFor(pc => pc.request.Phone)
				.Must(p => p == null || p.IsPhoneNumber())
				.WithMessage(ValidationLibrary.ValidPhoneError);
        }
	}
}
