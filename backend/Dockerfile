FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["queroCento-BE.csproj", ""]
RUN dotnet restore "queroCento-BE.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "queroCento-BE.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "queroCento-BE.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "queroCento-BE.dll"]