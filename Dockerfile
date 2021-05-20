FROM mcr.microsoft.com/dotnet/sdk as base

WORKDIR /app
COPY . .
RUN dotnet publish --configuration Release --output out Rooster.Client

FROM mcr.microsoft.com/dotnet/aspnet

WORKDIR /app
COPY --from=base /app/out .
CMD [ "dotnet", "Rooster.Client.dll" ]