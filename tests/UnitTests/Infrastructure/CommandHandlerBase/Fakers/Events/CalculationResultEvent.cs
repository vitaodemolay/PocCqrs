using System;
using Infrastructure.CommandHandlerBase.Messages;

namespace UnitTests.Infrastructure.CommandHandlerBase.Fakers.Events
{
    internal class CalculationResultEvent : Event
    {
        internal CalculationResultEvent(int result, string operation, Guid correlationId)
        : base(correlationId)
        {
            this.Result = result;
            this.Operation = operation;
            this.ErrorMessage = string.Empty;

        }

        internal CalculationResultEvent(string errorMessage, string operation, Guid correlationId)
        : base(correlationId)
        {
            this.Result = 0;
            this.Operation = operation;
            this.ErrorMessage = errorMessage;
        }
        
        internal int Result { get; private set; }
        internal string Operation { get; private set; }
        internal string ErrorMessage { get; private set; }

        internal bool IsSuccess => string.IsNullOrEmpty(this.ErrorMessage);
        internal bool IsFail => !this.IsSuccess;
    }
}