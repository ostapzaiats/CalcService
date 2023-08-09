FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CalcService.Backend.Api/CalcService.Backend.Api.csproj", "CalcService.Backend.Api/"]
RUN dotnet restore "CalcService.Backend.Api/CalcService.Backend.Api.csproj"
COPY . .
WORKDIR "/src/CalcService.Backend.Api"
RUN dotnet build "CalcService.Backend.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalcService.Backend.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalcService.Backend.Api.dll"]