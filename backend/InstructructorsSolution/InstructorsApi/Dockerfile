#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["InstructorsApi/InstructorsApi.csproj", "InstructorsApi/"]
RUN dotnet restore "InstructorsApi/InstructorsApi.csproj"
COPY . .
WORKDIR "/src/InstructorsApi"
RUN dotnet build "InstructorsApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InstructorsApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstructorsApi.dll"]