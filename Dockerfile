FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0.100 AS dev
ARG TARGETARCH
ENV PATH="$PATH:/root/.dotnet/tools"
WORKDIR /app

FROM dev AS build
COPY FantasyBaseball.PlayerService/FantasyBaseball.PlayerService.csproj .
RUN dotnet restore -a $TARGETARCH
COPY FantasyBaseball.PlayerService/ .
RUN dotnet publish -c Release -a $TARGETARCH --no-restore -o /app/out -v minimal

FROM mcr.microsoft.com/dotnet/aspnet:6.0.10
RUN useradd -u 5000 service-user && mkdir /app && chown -R service-user:service-user /app
ENV ASPNETCORE_URLS=http://+:8080
USER service-user:service-user
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "FantasyBaseball.PlayerService.dll"]