namespace Infrastructure.CommandHandlerBase.Contracts
{
    public interface IValidationResult
    {
        bool IsValid { get; }
        string[] Errors { get; }
    }
}
