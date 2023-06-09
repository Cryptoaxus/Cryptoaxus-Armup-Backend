namespace CryptoAxus.Application.Dto;

public class FixedPricedDto : BaseDto
{
    public string? NftCopyId { get; set; }

    public int? Quantity { get; set; }

    public decimal? PricePerItem { get; set; }

    public DateTime? FixedEndingDateTime { get; set; }

    public bool? SoftDelete { get; set; }

    public FixedPricedDto()
    {
    }
}