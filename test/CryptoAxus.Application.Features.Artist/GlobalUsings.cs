global using CryptoAxus.Application.Contracts.Repositories;
global using CryptoAxus.Application.Dto;
global using CryptoAxus.Application.Features.Artist.DeleteArtistById.Handler;
global using CryptoAxus.Application.Features.Artist.DeleteArtistById.Request;
global using CryptoAxus.Application.Features.Artist.DeleteArtistById.Response;
global using CryptoAxus.Application.Features.Artist.GetArtistById.Handler;
global using CryptoAxus.Application.Features.Artist.GetArtistById.Request;
global using CryptoAxus.Application.Features.Artist.GetArtistByUserId.Request;
global using CryptoAxus.Application.Features.Artist.PatchArtist.Handler;
global using CryptoAxus.Application.Features.Artist.PatchArtist.Request;
global using CryptoAxus.Application.Features.Artist.PostArtist.Handler;
global using CryptoAxus.Application.Features.Artist.PostArtist.Request;
global using CryptoAxus.Application.Features.Artist.GetOffersMadeByArtist.Handler;
global using CryptoAxus.Application.Features.Artist.GetOffersMadeByArtist.Request;
global using CryptoAxus.Application.Features.Artist.GetOffersMadeByArtist.Response;
global using CryptoAxus.Common.Response;
global using CryptoAxus.Common.Services.Contracts;
global using CryptoAxus.Application.Features.Artist.GetOffersReceivedByArtist.Handler;
global using CryptoAxus.Application.Features.Artist.GetOffersReceivedByArtist.Request;
global using CryptoAxus.Application.Features.Artist.GetOffersReceivedByArtist.Response;
global using CryptoAxus.Application.Features.Artist.GetArtistByUserId.Handler;
global using Mapster;
global using CryptoAxus.Common.Helpers;
global using CryptoAxus.Domain.Collections;
global using Microsoft.AspNetCore.JsonPatch;
global using Microsoft.AspNetCore.JsonPatch.Operations;
global using Microsoft.Extensions.Logging;
global using MongoDB.Bson;
global using MongoDB.Driver;
global using Moq;
global using Shouldly;
global using System.Linq.Expressions;
global using System.Net;
global using CryptoAxus.Application.Dto.Artist;
global using Xunit;