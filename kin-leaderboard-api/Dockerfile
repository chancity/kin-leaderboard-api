ARG REPO=mcr.microsoft.com/dotnet/core/runtime
FROM $REPO:3.0-stretch-slim

# Install ASP.NET Core
ENV ASPNETCORE_VERSION 3.0.0-preview4-19216-03

RUN curl -SL --output aspnetcore.tar.gz https://dotnetcli.blob.core.windows.net/dotnet/aspnetcore/Runtime/$ASPNETCORE_VERSION/aspnetcore-runtime-$ASPNETCORE_VERSION-linux-x64.tar.gz \
    && aspnetcore_sha512='bf22533969a67d3bd5e16cb5a5c64c63b9ac99cd69ba6c6a04384e3b786cdb80196a61fb0a69706f5c24a44636a17ba86dd35a2c3d4e43f7447cb6befc198327' \
    && echo "$aspnetcore_sha512  aspnetcore.tar.gz" | sha512sum -c - \
    && tar -zxf aspnetcore.tar.gz -C /usr/share/dotnet ./shared/Microsoft.AspNetCore.App \
    && rm aspnetcore.tar.gz

WORKDIR /app
EXPOSE 5000

FROM buildpack-deps:stretch-scm

# Install .NET CLI dependencies
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
        libc6 \
        libgcc1 \
        libgssapi-krb5-2 \
        libicu57 \
        libssl1.1 \
        libstdc++6 \
        zlib1g \
    && rm -rf /var/lib/apt/lists/*

# Install .NET Core SDK
ENV DOTNET_SDK_VERSION 3.0.100-preview4-011223

RUN curl -SL --output dotnet.tar.gz https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$DOTNET_SDK_VERSION/dotnet-sdk-$DOTNET_SDK_VERSION-linux-x64.tar.gz \
    && dotnet_sha512='b416dd4014ad62c7d19413c44738f1cc6152c94570c31dc953be16bfeadecf449b2aab7ecc09c9d3fcd12b2d440f281a0c8f1ad0635bc035adb34c26f8d1e2ae' \
    && echo "$dotnet_sha512 dotnet.tar.gz" | sha512sum -c - \
    && mkdir -p /usr/share/dotnet \
    && tar -zxf dotnet.tar.gz -C /usr/share/dotnet \
    && rm dotnet.tar.gz \
    && ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet

# Configure web servers to bind to port 80 when present
ENV ASPNETCORE_URLS=http://+:80 \
    # Enable detection of running in a container
    DOTNET_RUNNING_IN_CONTAINER=true \
    # Enable correct mode for dotnet watch (only mode supported in a container)
    DOTNET_USE_POLLING_FILE_WATCHER=true \
    # Skip extraction of XML docs - generally not useful within an image/container - helps performance
    NUGET_XMLDOC_MODE=skip

# Trigger first run experience by running arbitrary cmd
RUN dotnet help

# Install PowerShell global tool
ENV POWERSHELL_VERSION 6.2.0

RUN curl -SL --output PowerShell.Linux.x64.$POWERSHELL_VERSION.nupkg https://pwshtool.blob.core.windows.net/tool/$POWERSHELL_VERSION/PowerShell.Linux.x64.$POWERSHELL_VERSION.nupkg \
    && powershell_sha512='20b341fced6bc5b42d2eba0995a0877421ed22781f06a69699de2d507497ed217950831a9c9281eee73d78d5118be0adab30719aa959147b0fa6cc56655c2705' \
    && echo "$powershell_sha512  PowerShell.Linux.x64.$POWERSHELL_VERSION.nupkg" | sha512sum -c - \
    && mkdir -p /usr/share/powershell \
    && dotnet tool install --add-source / --tool-path /usr/share/powershell --version $POWERSHELL_VERSION PowerShell.Linux.x64 \
    && rm PowerShell.Linux.x64.$POWERSHELL_VERSION.nupkg \
    && ln -s /usr/share/powershell/pwsh /usr/bin/pwsh \
    # To reduce image size, remove the copy nupkg that nuget keeps.
    && find /usr/share/powershell -print | grep -i '.*[.]nupkg$' | xargs rm

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