namespace CryptoAxus.Domain.Interfaces;

public interface IBaseDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    ObjectId Id { get; }

    DateTime CreatedDate { get; }

    int CreatedBy { get; set; }

    public DateTime? LastModifiedDate { get; }

    public int? LastModifiedBy { get; }

    public bool IsDeleted { get; }
}