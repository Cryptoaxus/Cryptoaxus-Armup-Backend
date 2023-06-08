namespace CryptoAxus.Domain.Collections;

[BsonCollection("Biding")]
public class BidingDocument : BaseDocument
{
    [BsonElement(elementName: "nftId", Order = 2)]
    public string NftId { get; set; }

    [BsonElement(elementName: "biddingPrice", Order = 3)]
    public decimal BiddingPrice { get; set; }

    [BsonElement(elementName: "artistWalletAddress", Order = 4)]
    public string ArtistWalletAddress { get; set; }

    [BsonElement(elementName: "fromWalletAddress", Order = 5)]
    public string FromWalletAddress { get; set; }

    [BsonElement(elementName: "bidderUserName", Order = 6)]
    public string? BidderUserName { get; set; } 

    [BsonElement(elementName: "highestBid", Order = 7)]
    public bool HighestBid { get; set; }

    public BidingDocument() : base()

    {
    }

    public BidingDocument(ObjectId id, 
                          string nftId,
                          decimal biddingPrice,
                          string minimumBid,
                          string artistWalletAddress,
                          string fromWalletAddress,
                          bool highestBid,
                          ObjectId createdBy,
                          DateTime? lastModifiedDate = null,
                          ObjectId? lastModifiedBy = null,
                          string? bidderUserName = null,
                          bool isDeleted = false)
                          : base(id,
                                 createdBy,
                                 lastModifiedDate,
                                 lastModifiedBy,
                                 isDeleted)
    {
        Id = id;
        NftId = nftId;
        BiddingPrice = biddingPrice;
        ArtistWalletAddress = artistWalletAddress;
        FromWalletAddress = fromWalletAddress;
        BidderUserName = bidderUserName;
        HighestBid = highestBid;
        CreatedBy = createdBy;
        LastModifiedDate = lastModifiedDate;
        LastModifiedBy = lastModifiedBy;
        IsDeleted = isDeleted;
    }
}


