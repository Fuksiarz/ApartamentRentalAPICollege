
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .

WORKDIR /src/ApartamentRental.API
RUN dotnet publish ApartamentRental.API.csproj -c Relase -o /app/publish

FROM build AS tests
WORKDIR /src/ApartamentRental.Tests
RUN dotnet test

FROM build AS update-database
WORKDIR /src
RUN dotnet tool Install --global dotnet-ef
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet ef database update --project ApartamentRental.Infrastructure --startup-project ApartamentRental.API

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=update-database /src/ApartamentRental.API/dbo.ApartamentRental.db .
COPY --from=update-database /app/publish .
ENTRYPOINT ["dotnet","ApartamentRental.API.dll"]
