// Global using directives

global using CryptoAxus.API.ApiHelper;
global using CryptoAxus.API.Extensions;
global using CryptoAxus.API.Filters;
global using CryptoAxus.API.Middlewares;
global using CryptoAxus.Application;
global using CryptoAxus.Application.Dto.Artist;
global using CryptoAxus.Application.Dto.Nft;
global using CryptoAxus.Application.Features.Artist.DeleteArtistById.Request;
global using CryptoAxus.Application.Features.Artist.DeleteArtistById.Response;
global using CryptoAxus.Application.Features.Artist.GetArtistById.Request;
global using CryptoAxus.Application.Features.Artist.GetArtistByUserId.Request;
global using CryptoAxus.Application.Features.Artist.GetArtistByUserId.Response;
global using CryptoAxus.Application.Features.Artist.GetOffersMadeByArtist.Request;
global using CryptoAxus.Application.Features.Artist.GetOffersMadeByArtist.Response;
global using CryptoAxus.Application.Features.Artist.GetOffersReceivedByArtist.Request;
global using CryptoAxus.Application.Features.Artist.GetOffersReceivedByArtist.Response;
global using CryptoAxus.Application.Features.Artist.PatchArtist.Request;
global using CryptoAxus.Application.Features.Artist.PatchArtist.Response;
global using CryptoAxus.Application.Features.Artist.PostArtist.Request;
global using CryptoAxus.Application.Features.Artist.PostArtist.Response;
global using CryptoAxus.Application.Features.Artist.PostUpsertArtist.Request;
global using CryptoAxus.Application.Features.NFT.DeleteNftById.Request;
global using CryptoAxus.Application.Features.NFT.DeleteNftById.Response;
global using CryptoAxus.Application.Features.NFT.GetAllNft.Request;
global using CryptoAxus.Application.Features.NFT.GetAllNft.Response;
global using CryptoAxus.Application.Features.NFT.GetNftById.Request;
global using CryptoAxus.Application.Features.NFT.GetNftById.Response;
global using CryptoAxus.Application.Features.NFT.PostNft.Request;
global using CryptoAxus.Application.Features.NFT.PostNft.Response;
global using CryptoAxus.Application.Features.NFT.PostNft.Validation;
global using CryptoAxus.Application.Features.NFT.PutLikeFavoriteNft.Request;
global using CryptoAxus.Application.Features.NFT.PutLikeFavoriteNft.Response;
global using CryptoAxus.Application.Features.NFT.PutNft.Request;
global using CryptoAxus.Application.Features.NFT.PutNft.Response;
global using CryptoAxus.Application.Features.NftCollection.PostNftCollection.Request;
global using CryptoAxus.Application.Features.NftCollection.PostNftCollection.Response;
global using CryptoAxus.Common;
global using CryptoAxus.Common.Attributes;
global using CryptoAxus.Common.Constants;
global using CryptoAxus.Common.Enumerations;
global using CryptoAxus.Common.Helpers;
global using CryptoAxus.Common.Response;
global using CryptoAxus.Infrastructure;
global using FluentValidation;
global using FluentValidation.AspNetCore;
global using MediatR;
global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.AspNetCore.JsonPatch;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.Filters;
global using Microsoft.AspNetCore.Mvc.Formatters;
global using Microsoft.AspNetCore.Mvc.ModelBinding;
global using Microsoft.AspNetCore.Mvc.Versioning;
global using Microsoft.Net.Http.Headers;
global using Microsoft.OpenApi.Models;
global using Newtonsoft.Json;
global using Serilog;
global using Serilog.Events;
global using Swashbuckle.AspNetCore.Filters;
global using System.Dynamic;
global using System.Net;
global using System.Reflection;
global using System.Text.Json;
global using CryptoAxus.Application.Features.NFT.GetLikeFavoriteNftByArtists.Request;
global using CryptoAxus.Application.Features.NFT.GetLikeFavoriteNftByArtists.Response;
global using CryptoAxus.Application.Features.NFT.GetNftByCollectionId.Request;
global using CryptoAxus.Application.Features.NFT.GetNftByCollectionId.Response;
global using CryptoAxus.Application.Features.NftCollection.DeleteNftCollectionById.Request;
global using CryptoAxus.Application.Features.NftCollection.DeleteNftCollectionById.Response;
global using CryptoAxus.Application.Features.NftCollection.GetNftCollectionById.Request;
global using CryptoAxus.Application.Features.NftCollection.GetNftCollectionById.Response;
global using CryptoAxus.Application.Features.NftCollection.GetNftCollections.Request;
global using CryptoAxus.Application.Features.NftCollection.GetNftCollections.Response;
global using CryptoAxus.Application.Features.NftCollection.GetNftCollectionsByCategory.Request;
global using CryptoAxus.Application.Features.NftCollection.GetNftCollectionsByCategory.Response;
global using CryptoAxus.Application.Features.NftCollection.GetNftCollectionsByWalletAddress.Request;
global using CryptoAxus.Application.Features.NftCollection.GetNftCollectionsByWalletAddress.Response;
global using ValidationException = CryptoAxus.Common.Response.ValidationException;