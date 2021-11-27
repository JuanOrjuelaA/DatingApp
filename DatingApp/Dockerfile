#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DatingApp/DatingApp.csproj", "DatingApp/"]
COPY ["DatingApp.Infraestructure/DatingApp.Infrastructure.csproj", "DatingApp.Infraestructure/"]
COPY ["DatingApp.Models/DatingApp.Models.csproj", "DatingApp.Models/"]
COPY ["DatingApp.Services/DatingApp.Services.csproj", "DatingApp.Services/"]
RUN dotnet restore "DatingApp/DatingApp.csproj"
COPY . .
WORKDIR "/src/DatingApp"
RUN dotnet build "DatingApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DatingApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DatingApp.dll"]