# === Test Stage ===
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS test
WORKDIR /src

# Copy both .csproj files
COPY ../backend/backend.csproj ./backend/
COPY ../Backend.Test/Backend.Test.csproj ./Backend.Test/

# Restore test project dependencies
RUN dotnet restore ./Backend.Test/Backend.Test.csproj

# Copy full source
COPY ../backend ./backend/
COPY ../Backend.Test ./Backend.Test/

# Run tests
RUN dotnet test ./Backend.Test/Backend.Test.csproj --no-restore --verbosity normal


# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "backend.dll"]
