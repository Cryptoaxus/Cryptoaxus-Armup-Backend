namespace CryptoAxus.Application.Dto;

public class MainNftsDto : BaseDto
{
    public string? ContractAddress { get; set; }

    public string? Hash { get; set; }

    public string? ImageStoragelink { get; set; }

    public string? Signature { get; set; }

    public int? TokenId { get; set; }

    public int? Quantity { get; set; }

    public string? Name { get; set; }

    public string? Url { get; set; }

    public string? Description { get; set; }

    public int? Collection { get; set; }

    public string? CollectionId { get; set; }

    public string? Blockchain { get; set; }

    public int? CreaterEarnings { get; set; }

    public MainNftsDto()
    {
    }
}