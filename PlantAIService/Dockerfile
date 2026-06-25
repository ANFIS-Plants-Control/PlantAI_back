FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . ./
RUN dotnet restore ./PlantAIService.Presentation
RUN dotnet publish ./PlantAIService.Presentation -o out

FROM mcr.microsoft.com/dotnet/aspnet:10.0.0

WORKDIR /PlantAIService
COPY --from=build /src/out /PlantAIService
EXPOSE 8081
ENTRYPOINT [ "dotnet", "PlantAIService.dll" ]