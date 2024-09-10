
# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:8.0 as build-env
WORKDIR /src
COPY ./*.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /publish
COPY --from=build-env /publish .
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "BackEnd.dll"]