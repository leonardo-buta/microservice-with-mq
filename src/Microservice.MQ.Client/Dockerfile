#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Microservice.MQ.Client/Microservice.MQ.Client.csproj", "src/Microservice.MQ.Client/"]
COPY ["src/Microservice.MQ.CrossCut/Microservice.MQ.CrossCut.csproj", "src/Microservice.MQ.CrossCut/"]
COPY ["src/Microservice.MQ.Service.Domain/Microservice.MQ.Service.Domain.csproj", "src/Microservice.MQ.Service.Domain/"]
COPY ["src/Microservice.MQ.Service/Microservice.MQ.Service.csproj", "src/Microservice.MQ.Service/"]
RUN dotnet restore "src/Microservice.MQ.Client/Microservice.MQ.Client.csproj"
COPY . .
WORKDIR "/src/src/Microservice.MQ.Client"
RUN dotnet build "Microservice.MQ.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservice.MQ.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservice.MQ.Client.dll"]