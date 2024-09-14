
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

ENV DB_HOST=
ENV DB_USER=
ENV DB_PASSWORD=
ENV DB_SCHEMA=

WORKDIR /src
COPY ./*.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /publish
COPY --from=build-env /publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "BackEnd.dll"]