FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY /src
COPY ["ServiceAPI/ServiceAPI.csproj", "ServiceAPI/"]
RUN dotnet restore "ServiceAPI/ServiceAPI.csproj"
COPY . .
WORKDIR "/src/ServiceAPI.csproj" 
RUN dotnet build "ServiceAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServiceAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceAPI.dll"]
