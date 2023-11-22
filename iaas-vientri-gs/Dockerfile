#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["iaas-vientri-gs/iaas-vientri-gs.csproj", "iaas-vientri-gs/"]
RUN dotnet restore "iaas-vientri-gs/iaas-vientri-gs.csproj"
COPY . .
WORKDIR "/src/iaas-vientri-gs"
RUN dotnet build "iaas-vientri-gs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "iaas-vientri-gs.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "iaas-vientri-gs.dll"]