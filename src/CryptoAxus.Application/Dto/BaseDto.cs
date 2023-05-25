namespace CryptoAxus.Application.Dto;

public abstract class BaseDto
{
    public ObjectId? Id { get; set; }

    public DateTime? CreatedDate { get; set; }

    public ObjectId? CreatedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public ObjectId? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }
}