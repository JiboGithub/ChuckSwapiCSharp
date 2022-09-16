#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ChuckSwapiCSharp.API/ChuckSwapiCSharp.API.csproj", "ChuckSwapiCSharp.API/"]
COPY ["ChuckSwapiCSharp.Service/ChuckSwapiCSharp.Service.csproj", "ChuckSwapiCSharp.Service/"]
COPY ["ChuckSwapiCSharp.Infrastructure/ChuckSwapiCSharp.Infrastructure.csproj", "ChuckSwapiCSharp.Infrastructure/"]
COPY ["ChuckSwapiCSharp.Domain/ChuckSwapiCSharp.Domain.csproj", "ChuckSwapiCSharp.Domain/"]
RUN dotnet restore "ChuckSwapiCSharp.API/ChuckSwapiCSharp.API.csproj"
COPY . .
WORKDIR "/src/ChuckSwapiCSharp.API"
RUN dotnet build "ChuckSwapiCSharp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChuckSwapiCSharp.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChuckSwapiCSharp.API.dll"]