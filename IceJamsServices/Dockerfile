FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["IceJamsServices/IceJamsServices.csproj", "IceJamsServices/"]
COPY ["IceJamsAgent/IceJamsAgent.csproj", "IceJamsAgent/"]
COPY ["IceJamsDB/IceJamsDB.csproj", "IceJamsDB/"]
RUN dotnet restore "IceJamsServices/IceJamsServices.csproj"
COPY . .
WORKDIR "/src/IceJamsServices"
RUN dotnet build "IceJamsServices.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "IceJamsServices.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "IceJamsServices.dll"]