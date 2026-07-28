#stage 1 from microsoft sdk image
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY . .

RUN dotnet restore TurnMeUp.sln 

RUN dotnet publish src/TurnMeUp.Api/TurnMeUp.Api.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

#stage 2 from runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

ENTRYPOINT ["dotnet", "TurnMeUp.Api.dll"]
