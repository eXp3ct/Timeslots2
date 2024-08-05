#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Expect.Timelots.Auth/Expect.Timelots.Auth.csproj", "Expect.Timelots.Auth/"]
COPY ["Expect.Timeslots.Api/Expect.Timeslots.Api.csproj", "Expect.Timeslots.Api/"]
COPY ["Expect.Timeslots.Data/Expect.Timeslots.Data.csproj", "Expect.Timeslots.Data/"]
COPY ["Expect.Timeslots.Domain/Expect.Timeslots.Domain.csproj", "Expect.Timeslots.Domain/"]
COPY ["Expect.Timeslots.Infrastructure/Expect.Timeslots.Infrastructure.csproj", "Expect.Timeslots.Infrastructure/"]
RUN dotnet restore "./Expect.Timelots.Auth/Expect.Timelots.Auth.csproj"
COPY . .
WORKDIR "/src/Expect.Timelots.Auth"
RUN dotnet build "./Expect.Timelots.Auth.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Expect.Timelots.Auth.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Expect.Timelots.Auth.dll"]