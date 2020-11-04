#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ./CommonLibrary/CommonLibrary.csproj ./CommonLibrary/
COPY ./GwWebApi01/GwWebApi01.csproj ./GwWebApi01/
RUN dotnet restore "./GwWebApi01/GwWebApi01.csproj"
COPY . .
WORKDIR "/src/GwWebApi01/"
RUN dotnet build "GwWebApi01.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GwWebApi01.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GwWebApi01.dll"]
