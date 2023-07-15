﻿global using CryptoAxus.Application.Contracts.Repositories;
global using CryptoAxus.Application.Dto;
global using CryptoAxus.Application.Dto.Nft;
global using CryptoAxus.Application.Features.Artist.DeleteArtistById.Request;
global using CryptoAxus.Application.Features.Artist.DeleteArtistById.Response;
global using CryptoAxus.Application.Features.Artist.GetArtistById.Request;
global using CryptoAxus.Application.Features.Artist.GetArtistById.Response;
global using CryptoAxus.Application.Features.Artist.GetArtistByUserId.Request;
global using CryptoAxus.Application.Features.Artist.GetArtistByWalletAddress.Response;
global using CryptoAxus.Application.Features.Artist.GetOffersMadeByArtist.Request;
global using CryptoAxus.Application.Features.Artist.GetOffersMadeByArtist.Response;
global using CryptoAxus.Application.Features.Artist.PatchArtist.Request;
global using CryptoAxus.Application.Features.Artist.PatchArtist.Response;
global using CryptoAxus.Application.Features.Artist.PostArtist.Request;
global using CryptoAxus.Application.Features.Artist.PostArtist.Response;
global using CryptoAxus.Application.Features.NFT.PostNft.Request;
global using CryptoAxus.Application.Features.NFT.PostNft.Response;
global using CryptoAxus.Common.Constants;
global using CryptoAxus.Common.Helpers;
global using CryptoAxus.Common.Response;
global using CryptoAxus.Common.Services.Contracts;
global using CryptoAxus.Domain.Collections;
global using CryptoAxus.Domain.Interfaces;
global using FluentValidation;
global using Mapster;
global using MediatR;
global using Microsoft.AspNetCore.JsonPatch;
global using Microsoft.AspNetCore.JsonPatch.Operations;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using MongoDB.Bson;
global using MongoDB.Driver;
global using Newtonsoft.Json;
global using Swashbuckle.AspNetCore.Filters;
global using System.Linq.Expressions;
global using System.Net;
global using System.Reflection;
global using JsonSerializer = System.Text.Json.JsonSerializer;