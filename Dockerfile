FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["University.web/University.web.csproj", "University.web/"]
RUN dotnet restore "University.web/University.web.csproj"
COPY . .
RUN dotnet build "University.web/University.web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "University.web/University.web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "University.web.dll"]