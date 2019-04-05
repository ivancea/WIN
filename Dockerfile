FROM mcr.microsoft.com/dotnet/core/sdk:3.0 as build
WORKDIR /app

RUN curl -sL https://deb.nodesource.com/setup_11.x | bash - \
    && apt-get install -y nodejs

COPY *.csproj ./
RUN dotnet restore

COPY ./ClientApp/package*.json ./ClientApp/

RUN cd ClientApp \
    && npm install

COPY . .
RUN dotnet publish -c Release -o build

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /app

COPY --from=build /app/build .

EXPOSE 80
EXPOSE 443

ENTRYPOINT [ "dotnet", "./WhatIsNext.dll" ]
