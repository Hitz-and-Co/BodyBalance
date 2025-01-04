# Basis-Image für die Ausführung (Produktion)
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 80

# Build-Image mit SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Nur die .csproj-Datei kopieren und Wiederherstellung ausführen
COPY ["BodyBalance_Backend.csproj", "./"]
RUN dotnet restore "./BodyBalance_Backend.csproj"

# Den Rest des Codes kopieren und bauen
COPY . .
RUN dotnet build "./BodyBalance_Backend.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Veröffentlichungsphase
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BodyBalance_Backend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Finales Image für Produktion
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BodyBalance_Backend.dll"]

# Zusatz: Optimierungen für kleinere Images und bessere Performance
# Installiere eventuell notwendige zusätzliche Bibliotheken
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

# Optional: Frontend-Konfiguration hinzufügen, falls es eine gibt
# FROM nginx:alpine AS frontend
# COPY /app/publish/wwwroot /usr/share/nginx/html
