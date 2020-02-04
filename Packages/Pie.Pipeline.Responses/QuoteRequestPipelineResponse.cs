using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Pie.Quote.Messages.Contracts;

namespace Packages.Pie.Pipeline.Responses
{
    public class QuoteRequestPipelineResponse
    {
        public QuoteResponse QuoteResponse { get; set; }

        public IEnumerable<ValidationFailure> ValidationFailures { get; set; } = Enumerable.Empty<ValidationFailure>();
    }
}
