# not tested to work
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NewsletterSignup/NewsletterSignup.csproj", "NewsletterSignup/"]
RUN dotnet restore "NewsletterSignup/NewsletterSignup.csproj"
WORKDIR "/src/NewsletterSignup"
COPY . .
RUN dotnet build -v d "NewsletterSignup.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -v d "NewsletterSignup.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM node:18 AS angular-build
WORKDIR /src
COPY ["NewsletterSignup/ClientApp/package-lock.json", "Angular/"]
COPY ["NewsletterSignup/ClientApp/package.json", "Angular/"]
WORKDIR "/src/Angular"
RUN npm ci
COPY ["NewsletterSignup/ClientApp/", "."]
RUN npm run build


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=angular-build /src/Angular/dist ./wwwroot
ENTRYPOINT ["dotnet", "NewsletterSignup.dll"]
