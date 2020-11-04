#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ./CommonLibrary/CommonLibrary.csproj ./CommonLibrary/
COPY ./BeWebApi01/BeWebApi01.csproj ./BeWebApi01/
RUN dotnet restore "./BeWebApi01/BeWebApi01.csproj"
COPY . .
WORKDIR "/src/BeWebApi01/"
RUN dotnet build "BeWebApi01.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BeWebApi01.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BeWebApi01.dll"]
