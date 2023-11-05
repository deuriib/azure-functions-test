FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AzureFunctions.Walkthrough/AzureFunctions.Walkthrough.csproj", "AzureFunctions.Walkthrough/"]
RUN dotnet restore "AzureFunctions.Walkthrough/AzureFunctions.Walkthrough.csproj"
COPY . .
WORKDIR "/src/AzureFunctions.Walkthrough"
RUN dotnet build "AzureFunctions.Walkthrough.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AzureFunctions.Walkthrough.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AzureFunctions.Walkthrough.dll"]
