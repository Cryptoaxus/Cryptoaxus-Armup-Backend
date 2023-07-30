namespace CryptoAxus.Domain.Interfaces;

public interface IBaseDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    ObjectId Id { get; }

    DateTime CreatedDate { get; }

    string CreatedBy { get; set; }

    DateTime? LastModifiedDate { get; }

    string? LastModifiedBy { get; }

    bool IsDeleted { get; }
}