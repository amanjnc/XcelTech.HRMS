#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["XcelTech.HRMS.Api/XcelTech.HRMS.Api.csproj", "XcelTech.HRMS.Api/"]
COPY ["XcelTech.HRMS.Bloc/XcelTech.HRMS.Bloc.csproj", "XcelTech.HRMS.Bloc/"]
COPY ["XcelTech.HRMS.Model/XcelTech.HRMS.Model.csproj", "XcelTech.HRMS.Model/"]
COPY ["XcelTech.HRMS.Helper/XcelTech.HRMS.Helper.csproj", "XcelTech.HRMS.Helper/"]
COPY ["XcelTech.HRMS.Repo/XcelTech.HRMS.Repo.csproj", "XcelTech.HRMS.Repo/"]
RUN dotnet restore "./XcelTech.HRMS.Api/XcelTech.HRMS.Api.csproj"
COPY . .
WORKDIR "/src/XcelTech.HRMS.Api"
RUN dotnet build "./XcelTech.HRMS.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./XcelTech.HRMS.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "XcelTech.HRMS.Api.dll"]