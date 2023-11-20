FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["lab1back/lab1back.csproj", "lab1back/"]
RUN dotnet restore "lab1back/lab1back.csproj"
COPY . ./
WORKDIR "/src/lab1back"
RUN dotnet build "lab1back.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "lab1back.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "lab1back.dll"]
