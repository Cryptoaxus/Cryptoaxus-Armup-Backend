﻿using CryptoAxus.Common.Constants;
using CryptoAxus.Common.Response;
using System.Net.Http.Headers;

namespace CryptoAxus.Common.Helpers;

public static class HelperMethods
{
    public static bool CheckIfMediaTypeIsValid<T>(string? mediaType,
                                                  out MediaTypeHeaderValue? parsedMediaType,
                                                  out BaseResponse<T>? responseValue)
    {
        bool isValid = MediaTypeHeaderValue.TryParse(input: mediaType, parsedValue: out parsedMediaType);
        responseValue = null;
        if (isValid) return true;
        responseValue = new BaseResponse<T>(statusCode: HttpStatusCode.UnsupportedMediaType, message: Messages.InvalidMediaType);
        return false;
    }

    public static bool CheckIfMediaTypeIsValid<T>(string? mediaType,
                                                  out MediaTypeHeaderValue? parsedMediaType,
                                                  out PaginationResponse<T>? responseValue)
    {
        bool isValid = MediaTypeHeaderValue.TryParse(input: mediaType, parsedValue: out parsedMediaType);
        responseValue = null;
        if (isValid) return true;
        responseValue = new PaginationResponse<T>(statusCode: HttpStatusCode.UnsupportedMediaType, message: Messages.InvalidMediaType);
        return false;
    }
}