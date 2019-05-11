FROM mcr.microsoft.com/dotnet/core/aspnet:3.0.0-preview5 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.0.0-preview5 AS build
WORKDIR /src
COPY ["kin-leaderboard-api/kin-leaderboard-api.csproj", "kin-leaderboard-api/"]
COPY ["BlazorFrontEnd/BlazorFrontEnd.csproj", "BlazorFrontEnd/"]
COPY ["kin-leaderboard-frontend.Shared/kin-leaderboard-frontend.Shared.csproj", "kin-leaderboard-frontend.Shared/"]
RUN dotnet restore "kin-leaderboard-api/kin-leaderboard-api.csproj"
COPY . .
WORKDIR "/src/kin-leaderboard-api"
RUN dotnet build "kin-leaderboard-api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "kin-leaderboard-api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "kin-leaderboard-api.dll"]