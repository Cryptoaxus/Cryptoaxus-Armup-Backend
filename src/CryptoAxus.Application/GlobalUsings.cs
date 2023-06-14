﻿global using CryptoAxus.Application.Contracts.Repositories;
global using CryptoAxus.Application.Dto;
global using CryptoAxus.Application.Features.Artist.GetArtistById.Request;
global using CryptoAxus.Application.Features.Artist.GetArtistById.Response;
global using CryptoAxus.Application.Features.Artist.PatchArtistUsername.Request;
global using CryptoAxus.Application.Features.Artist.PatchArtistUsername.Response;
global using CryptoAxus.Application.Features.Artist.Query;
global using CryptoAxus.Common.Constants;
global using CryptoAxus.Common.Helpers;
global using CryptoAxus.Common.Response;
global using CryptoAxus.Domain.Collections;
global using CryptoAxus.Domain.Interfaces;
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
