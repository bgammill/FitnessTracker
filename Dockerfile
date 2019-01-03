# get initial image
FROM microsoft/dotnet:sdk AS build-env

# set the working directory
WORKDIR /app

# copy project file to working directory
COPY *.csproj ./

# get necessary dependencies
RUN dotnet restore

# copy the remaining files to the working directory
COPY . ./

# build the project
RUN dotnet publish -c Release -o out

# get asp image
FROM microsoft/dotnet:aspnetcore-runtime

# set the working directory
WORKDIR /app

# copy all build files to working directory
COPY --from=build-env /app/out .

# set entry point
ENTRYPOINT ["dotnet", "FitnessTracker.dll"]
