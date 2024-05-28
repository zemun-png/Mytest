FROM nexus.aranuma.com:8888/aspnet:7.0-aranuma AS base
WORKDIR /app

FROM nexus.aranuma.com:8888/dotnetcore:7.0-alpine-aranuma AS build
WORKDIR /src

COPY . . 

ADD ./nuget.config  ~/.nuget/NuGet/NuGet.Config

RUN dotnet restore -r linux-musl-x64 --configfile=~/.nuget/NuGet/NuGet.Config
COPY . .

#COPY ./src/Presentation/Ara.SmartHSE.WebUI/Config ./Config

RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5000

ARG COMMIT_ID
ARG BUILD_ID
LABEL COMMIT_ID=${COMMIT_ID}
LABEL BUILD_ID=${BUILD_ID}

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet","Ara.SmartHSE.WebUI.dll"]
