FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8000
EXPOSE 8001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["./AlDenteAPI.csproj", "./"]
RUN dotnet restore "./AlDenteAPI.csproj"
COPY . .

RUN dotnet build "./AlDenteAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AlDenteAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# COPY ./https/aspnetapp.pfx /https/
ENTRYPOINT ["dotnet", "AlDenteAPI.dll"]