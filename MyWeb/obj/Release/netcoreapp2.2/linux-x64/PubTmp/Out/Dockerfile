FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["MyWeb/MyWeb.csproj", "MyWeb/"]
COPY ["service/service.csproj", "service/"]
RUN dotnet restore "MyWeb/MyWeb.csproj"
COPY . .
WORKDIR "/src/MyWeb"
RUN dotnet build "MyWeb.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MyWeb.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MyWeb.dll"]