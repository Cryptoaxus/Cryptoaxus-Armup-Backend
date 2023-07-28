namespace CryptoAxus.Application.Dto.Nft;

public class UpdateNftDto
{
    /// <summary>
    /// Contract address value
    /// <example>0x50251526b476CA288AD6a754aaC7A1455130f4d6</example>
    /// </summary>
    public string? ContractAddress { get; set; }

    /// <summary>
    /// Has value for nft
    /// <example>QmZfnCHWuv9pxg13bBJgZ99xZ8ravRk1RNVtRNHqWWcnF8</example>
    /// </summary>
    public string? Hash { get; set; }

    /// <summary>
    /// Url to store the images
    /// <example>https://armup.mypinata.cloud/ipfs/</example>
    /// </summary>
    public string? ImageStorageLink { get; set; }

    /// <summary>
    /// Image signature
    /// <example>0x29f8329e9e6d0e221ecb4bb7525968688c8f47311929ec4</example>
    /// </summary>
    public string? Signature { get; set; }

    /// <summary>
    /// Token id
    /// <example>344606</example>
    /// </summary>
    public int? TokenId { get; set; }

    /// <summary>
    /// Quantity of nft available
    /// <example>10</example>
    /// </summary>
    public int? Quantity { get; set; }

    /// <summary>
    /// Nft name
    /// <example>Ford Mustang GT artwork</example>
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Url of the nft image
    /// <example>https://www.google.com/</example>
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    /// Description of the nft
    /// <example>State of the art muscle sports car that can cruise the streets</example>
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Collection name
    /// <example>Exotic cars collection</example>
    /// </summary>
    public string? Collection { get; set; }

    /// <summary>
    /// Collection id
    /// <example>6489ba26704991467e824e5a</example>
    /// </summary>
    public string? CollectionId { get; set; }

    /// <summary>
    /// Block chain name
    /// <example>Ethereum</example>
    /// </summary>
    public string? BlockChain { get; set; }

    /// <summary>
    /// Total earnings of creator
    /// <example>450</example>
    /// </summary>
    public int? CreatorEarnings { get; set; }

    /// <summary>
    /// Set's the id of the user who updated the record
    /// </summary>
    public ObjectId? LastUpdatedBy { get; set; }

    public UpdateNftDto(string? contractAddress,
                        string? hash,
                        string? imageStorageLink,
                        string? signature,
                        int? tokenId,
                        int? quantity,
                        string? name,
                        string? url,
                        string? description,
                        string? collection,
                        string? collectionId,
                        string? blockChain,
                        int? creatorEarnings,
                        string? lastUpdatedBy)
    {
        ContractAddress = contractAddress;
        Hash = hash;
        ImageStorageLink = imageStorageLink;
        Signature = signature;
        TokenId = tokenId;
        Quantity = quantity;
        Name = name;
        Url = url;
        Description = description;
        Collection = collection;
        CollectionId = collectionId;
        BlockChain = blockChain;
        CreatorEarnings = creatorEarnings;
        LastUpdatedBy = lastUpdatedBy.ToObjectId();
    }
}