FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
RUN apt-get update && apt-get install -y nodejs
COPY ["MansionRentBackend.API/*.csproj", "MansionRentBackend.API/"]
COPY ["MansionRentBackend.Application/*.csproj", "MansionRentBackend.Application/"]
COPY ["MansionRentBackend.Domain/*.csproj", "MansionRentBackend.Domain/"]
RUN dotnet restore "MansionRentBackend.API/MansionRentBackend.API.csproj"
COPY . .
WORKDIR "/src/MansionRentBackend.API"
RUN dotnet build "MansionRentBackend.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MansionRentBackend.API.csproj" -c Release -o /app

FROM build AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MansionRentBackend.API.dll"]