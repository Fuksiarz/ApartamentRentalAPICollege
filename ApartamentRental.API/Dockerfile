FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ApartamentRental.API/ApartamentRental.API.csproj", "ApartamentRental.API/"]
RUN dotnet restore "ApartamentRental.API/ApartamentRental.API.csproj"
COPY . .
WORKDIR "/src/ApartamentRental.API"
RUN dotnet build "ApartamentRental.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApartamentRental.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApartamentRental.API.dll"]
