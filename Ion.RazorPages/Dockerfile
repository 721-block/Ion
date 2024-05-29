FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Ion.RazorPages/Ion.RazorPages.csproj", "Ion.RazorPages/"]
COPY ["Ion.Server/Ion.Server.csproj", "Ion.Server/"]
COPY ["Ion.Application/Ion.Application.csproj", "Ion.Application/"]
COPY ["Ion.Domain/Ion.Domain.csproj", "Ion.Domain/"]
COPY ["ion.client/ion.client.esproj", "ion.client/"]
COPY ["Ion.Infrastructure/Ion.Infrastructure.csproj", "Ion.Infrastructure/"]
RUN dotnet restore "Ion.RazorPages/Ion.RazorPages.csproj"
COPY . .
WORKDIR "/src/Ion.RazorPages"
RUN dotnet build "Ion.RazorPages.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Ion.RazorPages.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ion.RazorPages.dll"]
