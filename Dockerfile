# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and project files
COPY CA.ClinicaIA.sln .
COPY CA.ClinicaIA.API/CA.ClinicaIA.API.csproj CA.ClinicaIA.API/
COPY CA.ClinicaIA.Application/CA.ClinicaIA.Application.csproj CA.ClinicaIA.Application/
COPY CA.ClinicaIA.Domain/CA.ClinicaIA.Domain.csproj CA.ClinicaIA.Domain/
COPY CA.ClinicaIA.Dto/CA.ClinicaIA.Dto.csproj CA.ClinicaIA.Dto/
COPY CA.ClinicaIA.Infra.Data/CA.ClinicaIA.Infra.Data.csproj CA.ClinicaIA.Infra.Data/
COPY CA.ClinicaIA.Infra.IoC/CA.ClinicaIA.Infra.IoC.csproj CA.ClinicaIA.Infra.IoC/
COPY CA.ClinicaIA.Infra.Services/CA.ClinicaIA.Infra.Services.csproj CA.ClinicaIA.Infra.Services/

# Restore dependencies
RUN dotnet restore

# Copy all source code
COPY . .

# Build and publish
WORKDIR /src/CA.ClinicaIA.API
RUN dotnet publish -c Release -o /app/publish --no-restore

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Create non-root user for security
RUN adduser --disabled-password --gecos '' appuser && chown -R appuser /app
USER appuser

# Copy published application
COPY --from=build /app/publish .

# Expose port
EXPOSE 8080

# Set environment variables
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# Health check
HEALTHCHECK --interval=30s --timeout=3s --start-period=5s --retries=3 \
    CMD curl -f http://localhost:8080/health || exit 1

ENTRYPOINT ["dotnet", "CA.ClinicaIA.API.dll"]
