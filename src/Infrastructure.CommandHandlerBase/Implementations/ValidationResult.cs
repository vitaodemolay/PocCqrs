using Infrastructure.CommandHandlerBase.Contracts;
using System;
using System.Text;

namespace Infrastructure.CommandHandlerBase.Implementations
{
    public sealed class ValidationResult : IValidationResult
    {

        public ValidationResult()
        {
            Errors = null;
        }

        public ValidationResult(string[] errors)
        {
            Errors = errors;
        }

        public ValidationResult(StringBuilder errors)
        {
            Errors = errors.ToString().Split(Environment.NewLine.ToCharArray());
        }

        public bool IsValid => Errors is null || Errors.Length <= 0;

        public string[] Errors { get; private set; }
    }
}
