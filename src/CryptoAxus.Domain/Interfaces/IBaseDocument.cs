namespace CryptoAxus.Domain.Interfaces;

public interface IBaseDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    ObjectId Id { get; }

    DateTime CreatedDate { get; }

    ObjectId CreatedBy { get; set; }

    DateTime? LastModifiedDate { get; }

    ObjectId? LastModifiedBy { get; }

    bool IsDeleted { get; }
}