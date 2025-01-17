#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SNGPublicAPI/SNGPublicAPI.csproj", "SNGPublicAPI/"]
COPY ["OWSExternalLoginProviders/OWSExternalLoginProviders.csproj", "OWSExternalLoginProviders/"]
COPY ["OWSShared/OWSShared.csproj", "OWSShared/"]
COPY ["OWSData/OWSData.csproj", "OWSData/"]
RUN dotnet restore "SNGPublicAPI/SNGPublicAPI.csproj"
COPY . .
WORKDIR "/src/SNGPublicAPI"
RUN dotnet build "SNGPublicAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SNGPublicAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SNGPublicAPI.dll"]
