namespace CryptoAxus.Application.Dto;

public abstract class BaseDto
{
    public ObjectId? Id { get; private init; }

    public DateTime? CreatedDate { get; set; }

    public ObjectId? CreatedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public ObjectId? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    protected BaseDto()
    {
    }

    protected BaseDto(ObjectId? id = null,
                      ObjectId? createdBy = null,
                      DateTime? lastModifiedDate = null,
                      ObjectId? lastModifiedBy = null,
                      bool isDeleted = false)
                      => (Id, CreatedBy, LastModifiedDate, LastModifiedBy, IsDeleted)
                      = (id, createdBy, lastModifiedDate, lastModifiedBy, isDeleted);
}