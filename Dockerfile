FROM microsoft/dotnet:2.2-sdk AS base
WORKDIR /app
ARG version=1.0.0
 
# Copy csproj and restore as distinct layers
COPY find.water.sln ./
COPY ./src/app/ ./src/app
COPY ./src/core/ ./src/core
COPY ./src/test/ ./src/test

# restore for all projects
RUN dotnet restore
 
# test
# use the label to identity this layer later
LABEL test=true
# install the report generator tool
RUN dotnet tool install dotnet-reportgenerator-globaltool --version 4.0.6 --tool-path /tools
# run the test and collect code coverage (requires coverlet.msbuild to be added to test project)
# for exclude, use %2c for ,
RUN dotnet test  /p:CollectCoverage=true /p:CoverletOutputFormat=opencover ./src/test/test.csproj
# generate html reports using report generator tool
RUN /tools/reportgenerator "-reports:./src/test/coverage.opencover.xml" "-targetdir:./src/test/Reports"

RUN ls -la ./src/test/Reports
 
# build and publish
RUN dotnet publish ./src/app/app.csproj -c Release -o /app/out
 
# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=base /app/out .
ENTRYPOINT ["dotnet", "app.dll"]