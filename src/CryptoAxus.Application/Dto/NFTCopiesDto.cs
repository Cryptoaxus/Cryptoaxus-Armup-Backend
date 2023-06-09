namespace CryptoAxus.Application.Dto;

public class NFTCopiesDto : BaseDto
{
    public string? NftId { get; set; }

    public string? Owner { get; set; }

    public string? OwnerName { get; set; }

    public int? Quantity { get; set; }

    public bool? IsCreator { get; set; }

    public int? MarketTokenId { get; set; }

    public NFTCopiesDto()
    {
    }
}