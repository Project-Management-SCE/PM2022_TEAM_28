FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
 WORKDIR /app
 EXPOSE 80
 EXPOSE 443
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
 WORKDIR /src
 COPY ["WebHoly/WebHoly.csproj", "WebHoly/"]
 RUN dotnet restore "WebHoly/WebHoly.csproj"
 COPY . .
 WORKDIR "/src/WebHoly"
 RUN dotnet build "WebHoly.csproj" -c Release -o /app/build

 FROM build AS publish
 RUN dotnet publish "WebHoly.csproj" -c Release -o /app/publish

 FROM base AS final
 WORKDIR /app
 COPY --from=publish /app/publish .
 ENTRYPOINT ["dotnet", "/WebHoly.dll"]
