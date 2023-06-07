namespace CryptoAxus.Domain.Collections;

[BsonCollection("AllEvent")]
public class AllEventDocument: BaseDocument
{
    [BsonElement(elementName: "nftId", Order = 2)]
    public string NftId { get; set; }

    [BsonElement(elementName: "marketTokenId", Order = 3)]
    public int MarketTokenId { get; set; }

    [BsonElement(elementName: "mintingContract", Order = 4)]
    public string MintingContract { get; set; }

    [BsonElement(elementName: "walletAddress", Order = 5)]
    public string? WalletAddress { get; set; } 

    [BsonElement(elementName: "tokenId", Order = 6)]
    public int TokenId { get; set; }

    [BsonElement(elementName: " quantity", Order = 7)]
    public int Quantity { get; set; }

    [BsonElement(elementName: "seller", Order = 8)]
    public string Seller { get; set; }

    [BsonElement(elementName: "eventName", Order = 9)]
    public string EventName { get; set; }

    [BsonElement(elementName: "buyer", Order = 10)]
    public string? Buyer { get; set; } 
    
    [BsonElement(elementName: "price", Order = 11)]
    public decimal Price{ get; set; }

    [BsonElement(elementName: "offerAmount", Order = 12)]
    public decimal? OfferAmount { get; set; }

    [BsonElement(elementName: "listedAt", Order = 13)]
    public DateTime? ListedAt { get; set; }

    [BsonElement(elementName: "listingEndAt", Order = 14)]
    public DateTime ListingEndAt { get; set; } 

    [BsonElement(elementName: "canceledAt", Order = 15)]
    public DateTime? CanceledAt { get; set; } 

    [BsonElement(elementName: "soldAt", Order = 16)]
    public DateTime? SoldAt{ get; set; } 

    [BsonElement(elementName: "isSold", Order = 17)]
    public bool  IsSold { get; set; }

    [BsonElement(elementName: "accepted", Order = 18)]
    public bool Accepted { get; set; }

    [BsonElement(elementName: "rejected", Order = 19)]
    public bool Rejected { get; set; }



    public AllEventDocument() : base()
    {
    }
    public AllEventDocument(ObjectId id, 
                string nftId,
                int marketTokenId,
                string mintingContract,
                int tokenId,
                int quantity,
                string seller,
                string eventName,
                decimal price,
                DateTime listingEndAt,
                bool isSold,
                bool accepted, 
                bool rejected,
                ObjectId createdBy,
                bool isDeleted = false,
                string? buyer = null,
                decimal? offerAmount = null,
                DateTime? listedAt = null,
                DateTime? canceledAt = null,
                DateTime? soldAt = null,
                String? walletAddress = null,
                DateTime? lastModifiedDate = null,
                ObjectId? lastModifiedBy = null)
                          : base(id,
                                 createdBy,
                                 lastModifiedDate,
                                 lastModifiedBy,
                                 isDeleted)
    {
         Id = id;
        NftId = nftId;
        MarketTokenId = marketTokenId;
        MintingContract = mintingContract;
        WalletAddress = walletAddress;
        TokenId = tokenId;
        Quantity = quantity;
        Seller = seller;
        EventName = eventName;
        Buyer = buyer;
        Price= price;
        OfferAmount = offerAmount;
        ListedAt = listedAt;
        ListingEndAt = listingEndAt;
        CanceledAt = canceledAt;
        SoldAt = soldAt;
        IsSold = isSold;
        Accepted = accepted;
        Rejected = rejected;
        CreatedBy = createdBy;
        LastModifiedDate = lastModifiedDate;
        LastModifiedBy = lastModifiedBy;
        IsDeleted = isDeleted;
    
}
}