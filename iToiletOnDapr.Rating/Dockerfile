FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BathroomFinderOnDapr.Rating/BathroomFinderOnDapr.Rating.csproj", "BathroomFinderOnDapr.Rating/"]
RUN dotnet restore "BathroomFinderOnDapr.Rating/BathroomFinderOnDapr.Rating.csproj"
COPY . .
WORKDIR "/src/BathroomFinderOnDapr.Rating"
RUN dotnet build "BathroomFinderOnDapr.Rating.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BathroomFinderOnDapr.Rating.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BathroomFinderOnDapr.Rating.dll"]
