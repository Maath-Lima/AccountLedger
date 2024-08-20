FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY . ./src
RUN cd ./src && \
    mkdir -p /home/site/wwwroot && \
    dotnet publish *.csproj --output /home/site/wwwroot

FROM mcr.microsoft.com/azure-functions/dotnet:4 AS base
COPY --from=build ["/home/site/wwwroot", "/home/site/wwwroot"]