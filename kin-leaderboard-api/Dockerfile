#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5000

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["kin-leaderboard-api/kin-leaderboard-api.csproj", "kin-leaderboard-api/"]
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