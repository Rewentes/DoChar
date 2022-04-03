FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DT-Char/DT-Char.csproj", "DT-Char/"]
RUN dotnet restore "DT-Char/DT-Char.csproj"
COPY . .
WORKDIR "/src/DT-Char"
RUN dotnet build "DT-Char.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DT-Char.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DT-Char.dll"]
