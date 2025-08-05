# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar todo el código fuente del proyecto
COPY . .

# Crear los directorios si no existen
RUN mkdir -p /app/build /app/publish

# Restaurar dependencias
RUN dotnet restore BanReservas.API.csproj

# Compilar el proyecto
RUN dotnet build BanReservas.API.csproj -c Release -o /app/build

# Publicar la aplicación
RUN dotnet publish BanReservas.API.csproj -c Release -o /app/publish

# Imagen final para ejecutar
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "BanReservas.API.dll"]
