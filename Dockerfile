FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS api
USER $APP_UID
WORKDIR /api
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Development
WORKDIR /src
COPY ["Ion.Server/Ion.Server.csproj", "Ion.Server/"]
COPY ["Ion.Application/Ion.Application.csproj", "Ion.Application/"]
COPY ["Ion.Domain/Ion.Domain.csproj", "Ion.Domain/"]
COPY ["Ion.Infrastructure/Ion.Infrastructure.csproj", "Ion.Infrastructure/"]
RUN dotnet restore "Ion.Server/Ion.Server.csproj"
COPY . .
WORKDIR "/src/Ion.Server"
RUN dotnet build "Ion.Server.csproj" -c $BUILD_CONFIGURATION -o /api/build

RUN dotnet publish "Ion.Server.csproj" -c $BUILD_CONFIGURATION -o /api/publish /p:UseAppHost=false

FROM api AS final
WORKDIR /api
COPY --from=publish /api/publish .
ENTRYPOINT ["dotnet", "Ion.Server.dll"]
