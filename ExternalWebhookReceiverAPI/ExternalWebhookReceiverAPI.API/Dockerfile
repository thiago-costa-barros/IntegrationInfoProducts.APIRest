# build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copiar solução inteira (inclui submodule CommonSolution)
COPY . .

# restaurar pacotes
RUN dotnet restore ExternalWebhookReceiverAPI/ExternalWebhookReceiverAPI.sln

# publicar somente a API
RUN dotnet publish ExternalWebhookReceiverAPI/ExternalWebhookReceiverAPI.API/ExternalWebhookReceiverAPI.API.csproj \
    -c Release -o /app/publish /p:UseAppHost=false

# runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
# Render injeta $PORT; a app deve escutar nele
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}
COPY --from=build /app/publish ./
ENTRYPOINT ["dotnet", "ExternalWebhookReceiverAPI.API.dll"]