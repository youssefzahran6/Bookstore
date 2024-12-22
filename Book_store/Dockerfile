# Use the official .NET SDK image for .NET 9.0 to build the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Set the working directory inside the container
WORKDIR /src

# Copy the project file and restore any dependencies (via dotnet restore)
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the files and build the app
COPY . ./
RUN dotnet publish -c Release -o /app/out

# Use the official .NET runtime image for .NET 9.0 to run the app
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copy the build output from the previous stage
COPY --from=build /app/out .

# Set the entry point to the application
ENTRYPOINT ["dotnet", "Book_store.dll"]
