FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Wishlist.PublicApi/Wishlist.PublicApi.csproj", "Wishlist.PublicApi/"]
RUN dotnet restore "Wishlist.PublicApi/Wishlist.PublicApi.csproj"
COPY . .
WORKDIR "/src/Wishlist.PublicApi"
RUN dotnet build "Wishlist.PublicApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Wishlist.PublicApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Wishlist.PublicApi.dll"]
