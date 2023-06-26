#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/CryptoAxus.API/CryptoAxus.API.csproj", "src/CryptoAxus.API/"]
COPY ["src/CryptoAxus.Application/CryptoAxus.Application.csproj", "src/CryptoAxus.Application/"]
COPY ["src/CryptoAxus.Common/CryptoAxus.Common.csproj", "src/CryptoAxus.Common/"]
COPY ["src/CryptoAxus.Domain/CryptoAxus.Domain.csproj", "src/CryptoAxus.Domain/"]
COPY ["src/CryptoAxus.Infrastructure/CryptoAxus.Infrastructure.csproj", "src/CryptoAxus.Infrastructure/"]
RUN dotnet restore "src/CryptoAxus.API/CryptoAxus.API.csproj"
COPY . .
WORKDIR "/src/src/CryptoAxus.API"
RUN dotnet build "CryptoAxus.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CryptoAxus.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CryptoAxus.API.dll"]