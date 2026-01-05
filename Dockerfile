# 1. Build Phase
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY ["CineScope.csproj", "./"]
RUN dotnet restore "CineScope.csproj"

# Copy everything else and build
COPY . .
RUN dotnet publish "CineScope.csproj" -c Release -o /app/publish

# 2. Runtime Phase
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Set the port to 8080 (Render likes this port)
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "CineScope.dll"]