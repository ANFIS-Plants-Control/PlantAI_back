FROM mcr.microsoft.com/dotnet/aspnet:10.0.0

WORKDIR /AuthService

COPY ./AuthService.Presentation/bin/Release/net10.0/ .
EXPOSE 8080
ENTRYPOINT [ "dotnet", "AuthService.dll" ]
