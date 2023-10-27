# Use the official .NET Core SDK as a base image to build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the .NET Core Web API source code to the container
COPY Api/ /app

# Build the API (specify the startup project)
WORKDIR /app/W1EHUB.Api
RUN dotnet restore
RUN dotnet build -c Release -o /app/build

# Run Entity Framework Core migrations to update the database
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# Publish the API
RUN dotnet publish -c Release -o /app/publish

# Create the final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
COPY --from=build /app/publish .

# Expose the port the API runs on
EXPOSE 80
ENTRYPOINT ["dotnet", "W1EHUB.Api.dll"]

