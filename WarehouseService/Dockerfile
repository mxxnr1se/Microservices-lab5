FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WarehouseService.csproj", "./"]
RUN dotnet restore "WarehouseService.csproj"
COPY . .
RUN dotnet build "WarehouseService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WarehouseService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WarehouseService.dll"]
