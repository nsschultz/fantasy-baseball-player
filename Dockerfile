FROM --platform=$BUILDPLATFORM nschultz/fantasy-baseball-common-backend:1.1.2 AS dev
ARG TARGETARCH
ARG GITHUB_USERNAME
ARG GITHUB_TOKEN
RUN dotnet nuget add source \
    --username "$GITHUB_USERNAME" \
    --password "$GITHUB_TOKEN" \
    --store-password-in-clear-text \
    --name github \
    "https://nuget.pkg.github.com/nsschultz/index.json"

FROM dev AS ci
COPY . .

FROM dev AS build
COPY FantasyBaseball.PlayerService/FantasyBaseball.PlayerService.csproj .
RUN dotnet restore -a "$TARGETARCH"
COPY FantasyBaseball.PlayerService/ .
RUN dotnet publish -c Release -a "$TARGETARCH" --no-restore -o /app/out -v minimal

FROM mcr.microsoft.com/dotnet/aspnet:10.0
RUN apt-get update && \
    apt-get install -y --no-install-recommends curl && \
    rm -rf /var/lib/apt/lists/* && \
    useradd -u 5000 service-user && mkdir /app && chown -R service-user:service-user /app
ENV ASPNETCORE_URLS=http://+:8080
USER service-user:service-user
WORKDIR /app
COPY --from=build /app/out ./
HEALTHCHECK --interval=30s --timeout=10s --start-period=5s --retries=3 \
    CMD curl -f http://localhost:8080/api/health || exit 1
ENTRYPOINT ["dotnet", "FantasyBaseball.PlayerService.dll"]