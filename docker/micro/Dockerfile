# Use the official ASP.NET Core runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
ARG PORT
EXPOSE $PORT
ENV ASPNETCORE_URLS=http://+:${PORT}

# Use the official .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Introduce ARG for specifying the project directory and namespace dynamically
ARG PROJECT_DIR
ARG PROJECT_NAMESPACE
# print args
RUN echo "PROJECT_DIR: ${PROJECT_DIR}"
RUN echo "PROJECT_NAMESPACE: ${PROJECT_NAMESPACE}"

COPY ["${PROJECT_DIR}/${PROJECT_NAMESPACE}.csproj", "${PROJECT_DIR}/"]
RUN dotnet restore "${PROJECT_DIR}/${PROJECT_NAMESPACE}.csproj"

# Copy the remaining files and build the app
COPY . .
WORKDIR "/src/${PROJECT_DIR}"
RUN dotnet build "${PROJECT_NAMESPACE}.csproj" -c Release -o /app/build

# Publish the app to a folder for deployment
FROM build AS publish
RUN dotnet publish "${PROJECT_NAMESPACE}.csproj" -c Release -o /app/publish

# Create a new image for the app, using the base runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# Re-declare ARG in the final stage to make it available
ARG PROJECT_NAMESPACE
# Set the ARG value to an ENV variable so it's available at runtime
ENV PROJECT_NAMESPACE=${PROJECT_NAMESPACE}

# Use shell form of ENTRYPOINT to utilize the environment variable
ENTRYPOINT ["sh", "-c", "dotnet $PROJECT_NAMESPACE.dll"]