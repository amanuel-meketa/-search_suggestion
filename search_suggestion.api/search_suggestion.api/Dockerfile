FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["search_suggestion.api/search_suggestion.api.csproj", "search_suggestion.api/"]
COPY ["search_suggestion.application/search_suggestion.application.csproj", "search_suggestion.application/"]
COPY ["search_suggestion.data/search_suggestion.data.csproj", "search_suggestion.data/"]
RUN dotnet restore "./search_suggestion.api/./search_suggestion.api.csproj"
COPY . .
WORKDIR "/src/search_suggestion.api"
RUN dotnet build "./search_suggestion.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./search_suggestion.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "search_suggestion.api.dll"]