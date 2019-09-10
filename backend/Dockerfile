FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
COPY . .

CMD ASPNETCORE_URLS=https://*:$PORT dotnet queroCentoBE.dll