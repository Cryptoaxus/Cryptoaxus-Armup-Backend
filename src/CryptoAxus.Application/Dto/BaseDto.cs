namespace CryptoAxus.Application.Dto;

public abstract class BaseDto
{
    public ObjectId? Id { get; set; }

    public DateTime? CreatedDate { get; set; } 

    public ObjectId? CreatedBy { get; set; } 

    public DateTime? LastModifiedDate { get; set; }

    public ObjectId? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; } 

    protected BaseDto()
    {
    }

    protected BaseDto(ObjectId id,
                      ObjectId? createdBy = null,
                      DateTime? lastModifiedDate = null,
                      ObjectId? lastModifiedBy = null,
                      bool isDeleted = false)
                      => (Id, CreatedBy, LastModifiedDate, LastModifiedBy, IsDeleted)
                      = (id, createdBy, lastModifiedDate, lastModifiedBy, isDeleted);
}