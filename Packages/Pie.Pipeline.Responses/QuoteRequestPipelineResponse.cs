using System.Collections.Generic;
using FluentValidation.Results;
using MediatR;
using Pie.Quote.Messages.Contracts;
using Pie.Quote.Messages.Contracts.Post;

namespace Packages.Pie.Pipeline.Responses
{
    public class QuoteRequestPipelineResponse
    {
        public QuoteRequestPost QuoteRequestPost { get; set; }

        public QuoteRequest QuoteRequest { get; set; }

        public IEnumerable<ValidationFailure> ValidationFailures { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
