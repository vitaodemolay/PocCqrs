using Infrastructure.CommandHandlerBase.Contracts;

namespace Infrastructure.CommandHandlerBase.Messages
{
    public abstract class Command : MessageBase
    {
        protected Command() : base()
        {
        }

        public abstract IValidationResult Validate();
    }
}