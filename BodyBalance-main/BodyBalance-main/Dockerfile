# Unter https://aka.ms/customizecontainer erfahren Sie, wie Sie Ihren Debugcontainer anpassen und wie Visual Studio dieses Dockerfile verwendet, um Ihre Images für ein schnelleres Debuggen zu erstellen.

# Abhängig vom Betriebssystem der Hostcomputer, die die Container erstellen oder ausführen, muss das in der FROM-Anweisung angegebene Image möglicherweise geändert werden.
# Weitere Informationen finden Sie unter https://aka.ms/egmqtttroubleshoot.

# Diese Stufe wird verwendet, wenn sie von VS im Schnellmodus ausgeführt wird (Standardeinstellung für Debugkonfiguration).
FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Diese Stufe wird zum Erstellen des Dienstprojekts verwendet.
FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BodyBalance_Backend.csproj", "."]
RUN dotnet restore "./BodyBalance_Backend.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./BodyBalance_Backend.csproj" -c %BUILD_CONFIGURATION% -o /app/build

# Diese Stufe wird verwendet, um das Dienstprojekt zu veröffentlichen, das in die letzte Phase kopiert werden soll.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BodyBalance_Backend.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

# Diese Stufe wird in der Produktion oder bei Ausführung von VS im regulären Modus verwendet (Standard, wenn die Debugkonfiguration nicht verwendet wird).
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BodyBalance_Backend.dll"]