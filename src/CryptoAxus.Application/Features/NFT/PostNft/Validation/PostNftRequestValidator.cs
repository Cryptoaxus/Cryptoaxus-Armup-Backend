namespace CryptoAxus.Application.Features.NFT.PostNft.Validation;

public class PostNftRequestValidator : AbstractValidator<CreateNftDto>
{
    public PostNftRequestValidator()
    {
        RuleFor(x => x.ContractAddress)
               .NotEmpty()
               .WithMessage("{PropertyName} can not be empty.")
               .NotNull()
               .WithMessage("{PropertyName} can not be null.");

        RuleFor(x => x.Hash)
               .NotEmpty()
               .WithMessage("{PropertyName} can not be empty.")
               .NotNull()
               .WithMessage("{PropertyName} can not be null.")
               .MaximumLength(255)
               .WithMessage("{PropertyName} can not exceed length of 255 characters.");

        RuleFor(x => x.ImageStorageLink)
               .NotEmpty()
               .WithMessage("{PropertyName} can not be empty.")
               .NotNull()
               .WithMessage("{PropertyName} can not be null.");

        RuleFor(x => x.Signature)
               .NotEmpty()
               .WithMessage("{PropertyName} can not be empty.")
               .NotNull()
               .WithMessage("{PropertyName} can not be null.");

        RuleFor(x => x.TokenId)
               .NotNull()
               .WithMessage("{PropertyName} can not be null.")
               .GreaterThan(0)
               .WithMessage("{PropertyName} should be greater than 0.");

        RuleFor(x => x.Quantity)
               .NotNull()
               .WithMessage("{PropertyName} can not be null.")
               .GreaterThan(0)
               .WithMessage("{PropertyName} should be greater than 0.");

        RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage("{PropertyName} can not be empty.")
               .NotNull()
               .WithMessage("{PropertyName} can not be null.")
               .MaximumLength(255)
               .WithMessage("{PropertyName} can not exceed length of 255 characters.");

        RuleFor(x => x.Url)
               .NotEmpty()
               .WithMessage("{PropertyName} can not be empty.")
               .NotNull()
               .WithMessage("{PropertyName} can not be null.");

        RuleFor(x => x.Description)
               .NotEmpty()
               .WithMessage("{PropertyName} can not be empty.")
               .NotNull()
               .WithMessage("{PropertyName} can not be null.")
               .MaximumLength(1000)
               .WithMessage("{PropertyName} can not exceed length of 1000 characters.");

        RuleFor(x => x.Collection)
               .NotEmpty()
               .WithMessage("{PropertyName} can not be empty.")
               .NotNull()
               .WithMessage("{PropertyName} can not be null.")
               .MaximumLength(255)
               .WithMessage("{PropertyName} can not exceed length of 255 characters.");

        RuleFor(x => x.CollectionId)
               .NotEmpty()
               .WithMessage("{PropertyName} can not be empty.")
               .NotNull()
               .WithMessage("{PropertyName} can not be null.");

        RuleFor(x => x.BlockChain)
               .NotEmpty()
               .WithMessage("{PropertyName} can not be empty.")
               .NotNull()
               .WithMessage("{PropertyName} can not be null.")
               .MaximumLength(255)
               .WithMessage("{PropertyName} can not exceed length of 255 characters.");

        RuleFor(x => x.CreatorEarnings)
               .NotNull()
               .WithMessage("{PropertyName} can not be null.")
               .GreaterThan(0)
               .WithMessage("{PropertyName} should be greater than 0.");
    }
}