namespace CryptoAxus.Application.Features;

public abstract class BaseHandler<THandler> where THandler : class
{
    protected readonly ILogger<THandler>? Logger;

    protected BaseHandler()
    {
    }

    protected BaseHandler(ILogger<THandler> logger)
    {
        Logger = logger ?? throw new ArgumentNullException(nameof(logger), Messages.ArgumentNullException);
    }
}