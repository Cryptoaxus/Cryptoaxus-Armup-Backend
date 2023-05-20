namespace CryptoAxus.Common.Response;

public class ValidationException : ResponseEntity
{
    /// <summary>
    /// Validation error list
    /// </summary>
    [JsonPropertyOrder(3)]
    internal IReadOnlyList<ValidationError>? Errors { get; set; }

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