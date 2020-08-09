using System;
using Infrastructure.CommandHandlerBase.Messages;

namespace UnitTests.Infrastructure.CommandHandlerBase.Fakers.Events
{
    internal class CalculationResultEvent : Event
    {
        public CalculationResultEvent(int result, string operation, Guid correlationId)
        : base(correlationId)
        {
            this.Result = result;
            this.Operation = operation;
            this.ErrorMessage = string.Empty;

        }

        public CalculationResultEvent(string errorMessage, string operation, Guid correlationId)
        : base(correlationId)
        {
            this.Result = 0;
            this.Operation = operation;
            this.ErrorMessage = errorMessage;
        }
        
        public int Result { get; private set; }
        public string Operation { get; private set; }
        public string ErrorMessage { get; private set; }

        public bool IsSuccess => string.IsNullOrEmpty(this.ErrorMessage);
        public bool IsFail => !this.IsSuccess;
    }
}