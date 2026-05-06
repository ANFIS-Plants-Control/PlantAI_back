FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . ./
RUN dotnet restore ./AuthService.Presentation
RUN dotnet publish ./AuthService.Presentation -o out

FROM mcr.microsoft.com/dotnet/aspnet:10.0.0

WORKDIR /AuthService
COPY --from=build /src/out /AuthService/
EXPOSE 8080
ENTRYPOINT [ "dotnet", "AuthService.dll" ]
