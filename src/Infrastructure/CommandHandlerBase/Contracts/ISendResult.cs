namespace Infrastructure.CommandHandlerBase.Contracts
{
    public interface ISendResult
    {
        bool IsSuccess { get; }
        string[] Errors { get; }
    }
}
