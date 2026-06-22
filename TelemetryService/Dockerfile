FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . ./
RUN dotnet restore ./TelemetryService.Presentation
RUN dotnet publish ./TelemetryService.Presentation -o out
RUN apt-get update && apt-get install -y libgssapi-krb5-2

FROM mcr.microsoft.com/dotnet/aspnet:10.0.0

WORKDIR /TelemetryService
COPY --from=build /src/out /TelemetryService
EXPOSE 8081
ENTRYPOINT [ "dotnet", "TelemetryService.dll" ]