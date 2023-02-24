FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["UpSchool.Wasm/UpSchool.Wasm.csproj", "UpSchool.Wasm/"]
RUN dotnet restore "UpSchool.Wasm/UpSchool.Wasm.csproj"
COPY . .
WORKDIR "/src/UpSchool.Wasm"
RUN dotnet build "UpSchool.Wasm.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UpSchool.Wasm.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UpSchool.Wasm.dll"]
