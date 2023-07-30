namespace CryptoAxus.Application.Dto;

public abstract class BaseDto
{
    public ObjectId? Id { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    protected BaseDto()
    {
    }

    protected BaseDto(ObjectId? id = null,
                      string? createdBy = null,
                      DateTime? lastModifiedDate = null,
                      string? lastModifiedBy = null,
                      bool isDeleted = false)
                      => (Id, CreatedBy, LastModifiedDate, LastModifiedBy, IsDeleted)
                      = (id, createdBy, lastModifiedDate, lastModifiedBy, isDeleted);
}