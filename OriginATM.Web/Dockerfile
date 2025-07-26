# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["OriginATM.Web/OriginATM.Web.csproj", "OriginATM.Web/"]
COPY ["OriginATM.Repository/OriginATM.Repository.csproj", "OriginATM.Repository/"]
COPY ["OriginATM.Infraestructura/OriginATM.Infraestructura.csproj", "OriginATM.Infraestructura/"]
COPY ["OriginATM.Dominio/OriginATM.Dominio.csproj", "OriginATM.Dominio/"]
COPY ["OriginATM.sln", "./"]
RUN dotnet restore "OriginATM.Web/OriginATM.Web.csproj"

COPY . .
COPY OriginATM.Infraestructura/Scripts /src/OriginATM.Web/Scripts
WORKDIR "/src/OriginATM.Web"
RUN dotnet publish -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT=Production
EXPOSE 5000
ENTRYPOINT ["dotnet", "OriginATM.Web.dll"]
