FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Content.API/Content.API.csproj", "Content.API/"]
COPY ["Content.Infrastructure/Content.Infrastructure.csproj", "Content.Infrastructure/"]
COPY ["Content.Application/Content.Application.csproj", "Content.Application/"]
COPY ["Content.Domain/Content.Domain.csproj", "Content.Domain/"]
RUN dotnet restore "Content.API/Content.API.csproj"
COPY . .
WORKDIR "/src/Content.API"
RUN dotnet build "Content.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Content.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Content.API.dll"]
