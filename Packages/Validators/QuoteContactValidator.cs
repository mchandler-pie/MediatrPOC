using FluentValidation;
using Pie.Quote.Messages.Contracts.Post;

namespace Packages.Validators
{
	public class QuoteContactPostValidator : ValidatorBase<QuoteContactPost>
	{
		public QuoteContactPostValidator()
		{
			RuleFor(pc => pc.FirstName)
				.NotEmpty()
				.WithMessage(ValidationLibrary.RequiredError)
				.Must(fn => !string.IsNullOrWhiteSpace(fn))
				.WithMessage(ValidationLibrary.RequiredError);

			RuleFor(pc => pc.LastName)
				.NotEmpty()
				.WithMessage(ValidationLibrary.RequiredError)
				.Must(ln => !string.IsNullOrWhiteSpace(ln))
				.WithMessage(ValidationLibrary.RequiredError);

			RuleFor(pc => pc.Email)
				.NotEmpty()
				.WithMessage(ValidationLibrary.RequiredError)
				.Must(e => !string.IsNullOrWhiteSpace(e))
				.WithMessage(ValidationLibrary.RequiredError);

            RuleFor(pc => pc.Phone)
				.Must(p => p == null || p.IsPhoneNumber())
				.WithMessage(ValidationLibrary.ValidPhoneError);
        }
	}
}
