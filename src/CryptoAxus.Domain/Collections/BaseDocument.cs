namespace CryptoAxus.Domain.Collections;

public abstract class BaseDocument : IBaseDocument
{
    [BsonElement(elementName: "id", Order = 1), BsonRequired]
    public ObjectId Id { get; set; }

    [BsonElement(elementName: "createdDate"), BsonRequired]
    public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;

    [BsonElement(elementName: "createdBy"), BsonRequired]
    public string CreatedBy { get; set; }

    [BsonElement(elementName: "lastModifiedDate")]
    public DateTime? LastModifiedDate { get; set; }

    [BsonElement(elementName: "lastModifiedBy")]
    public string? LastModifiedBy { get; set; }

    [BsonElement(elementName: "isDeleted")]
    public bool IsDeleted { get; set; }

    protected BaseDocument()
    {
    }

    protected BaseDocument(ObjectId id,
                           string createdBy,
                           DateTime? lastModifiedDate = null,
                           string? lastModifiedBy = null,
                           bool isDeleted = false)
                           => (Id, CreatedBy, LastModifiedDate, LastModifiedBy, IsDeleted)
                           = (id, createdBy, lastModifiedDate, lastModifiedBy, isDeleted);
}