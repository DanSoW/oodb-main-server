FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["oodb-project.csproj", "."]
RUN dotnet restore "./oodb-project.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "oodb-project.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "oodb-project.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "oodb-project.dll"]