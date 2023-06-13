using CryptoAxus.Application.Dto;
using CryptoAxus.Domain.Collections;
using Mapster;

namespace CryptoAxus.Application.Mappings;

public class ArtistMappings
{
    public ArtistDto Map(in ArtistDocument source)
    {
        return new ArtistDto
        {
            Id = source.Id,
            Bio = source.Bio,
            CoverImageAddress = source.CoverImageAddress,
            Email = source.Email,
            Instagram = source.Instagram,
            ProfileImageAddress = source.ProfileImageAddress,
            Twitter = source.Twitter,
            UserWalletAddress = source.UserWalletAddress,
            Username = source.Username,
            Website = source.Website,
            CreatedBy = source.CreatedBy,
            CreatedDate = source.CreatedDate,
            LastModifiedBy = source.LastModifiedBy,
            LastModifiedDate = source.LastModifiedDate,
            IsDeleted = source.IsDeleted,
        };
    }

    public ArtistDocument Map(in ArtistDto source)
    {
        var destObj = source.Adapt<ArtistDocument>();
        return new ArtistDocument();
    }
}