FROM microsoft/dotnet:2.0-sdk

WORKDIR /app

COPY . .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet API_Users.dll