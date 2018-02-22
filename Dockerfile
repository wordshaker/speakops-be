# First Stage
FROM microsoft/dotnet:2.0.5-sdk-2.1.4 AS build-env
WORKDIR /app

COPY ./SpeakOps.Api/SpeakOps.Api.csproj ./
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o out

# Second Stage
FROM microsoft/dotnet:2.0.5-runtime
WORKDIR /app

COPY --from=build-env /app/SpeakOps.Api/out ./
ENTRYPOINT ["dotnet", "SpeakOps.Api.dll"]