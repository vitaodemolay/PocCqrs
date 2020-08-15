using Infrastructure.CommandHandlerBase.Contracts;
using System.Collections.Generic;

namespace Infrastructure.CommandHandlerBase.Implementations
{
    public sealed class SendResult : ISendResult
    {
        public SendResult()
        {
            Errors = null;
        }

        public SendResult(IValidationResult validationResult)
        {
            if (validationResult.IsValid)
            {
                Errors = null;
                return;
            }

            var _errors = new List<string>();
            _errors.Add("Command is not Valid");
            _errors.AddRange(validationResult.Errors);

            Errors = _errors.ToArray();
        }

        public bool IsSuccess =>  Errors is null || Errors.Length <= 0;

        public string[] Errors { get; private set; }
    }
}
