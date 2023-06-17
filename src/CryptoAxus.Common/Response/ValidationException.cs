namespace CryptoAxus.Common.Response;

public class ValidationException : ResponseEntity
{
    /// <summary>
    /// Validation error list
    /// </summary>
    [JsonPropertyOrder(3)]
    public IReadOnlyList<ValidationError>? Errors { get; private set; }

    private ValidationException() : base(statusCode: HttpStatusCode.UnprocessableEntity,
                                         message: Messages.ValidationError,
                                         isSuccessful: false)
    {
    }

    public ValidationException(IReadOnlyList<ValidationError> errors) : this()
    {
        Errors = errors;
    }
}