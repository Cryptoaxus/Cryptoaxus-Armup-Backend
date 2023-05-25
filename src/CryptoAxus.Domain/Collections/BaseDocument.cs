namespace CryptoAxus.Domain.Collections;

public abstract class BaseDocument : IBaseDocument
{
    [BsonElement(elementName: "id", Order = 1), BsonRequired]
    public ObjectId Id { get; set; }

    [BsonElement(elementName: "createdDate"), BsonRequired]
    public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;

    [BsonElement(elementName: "createdBy"), BsonRequired]
    public ObjectId CreatedBy { get; set; }

    [BsonElement(elementName: "lastModifiedDate")]
    public DateTime? LastModifiedDate { get; set; } = null;

    [BsonElement(elementName: "lastModifiedBy")]
    public ObjectId? LastModifiedBy { get; set; } = null;

    [BsonElement(elementName: "isDeleted")]
    public bool IsDeleted { get; set; } = false;

    protected BaseDocument()
    {
    }

    protected BaseDocument(ObjectId id,
                           ObjectId createdBy,
                           DateTime? lastModifiedDate = null,
                           ObjectId? lastModifiedBy = null,
                           bool isDeleted = false)
                           => (Id, CreatedBy, LastModifiedDate, LastModifiedBy, IsDeleted)
                           = (id, createdBy, lastModifiedDate, lastModifiedBy, isDeleted);
}