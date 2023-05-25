namespace CryptoAxus.Domain.Interfaces;

public interface IBaseDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    ObjectId Id { get; }

    DateTime CreatedDate { get; }

    ObjectId CreatedBy { get; set; }

    public DateTime? LastModifiedDate { get; }

    public ObjectId? LastModifiedBy { get; }

    public bool IsDeleted { get; }
}