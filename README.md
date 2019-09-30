# Water Overflow problem

> Welcome to the Water Overflow problem repository. The source code is created and ment to solve the water overflow problem.

## Overview

There is a stack of water glasses in a form of a triangle. 

When a liquid is poured into the top most glass any overflow is venly distributed between the glasses in the next row. That is, half of the overflow pours into the left glass while the remainder of the overflow pours into the right. 

This projects helps to calculate and ilustrate how much liquid is in the j'th glass of the i'th row when K liters are poured into the top most glass.

```
                    |_|
                   |_||_|
  Row(i)         |_||_||_|
                |_||_||_||_|
               |_||_||_||_||_|
                    ...
                 Glass(j)
```

## Requirements

- Docker version >= 18.09.2  or .Net Core >= 2.0

## Tech specs
- .net Core 2.2 
- dotnet test (NUnit, Moq)
- test coverage and reportgenerator to generate test report.
- docker for linux o windows (optional).
- Make GNU  (optional).

## Usage (Clone, restore, compile and run)

### Clone repository from github:

```
 git clone git@github.com:dcsanabria/find-water.git
 ```
 
### CD to the folder:
```
 cd find_water
 ```

### From Command Line (Using Docker):
Docker version needs to be installed. Download [here](https://hub.docker.com/)

- Build Docker:

 ```
 docker build -t find_water .
 ```

- Run Docker:

 ```
 docker build -t find_water .
 ```

 - Stop (and delete) Docker:

 ```
 docker stop find_water
 docker rm find_water
 ```

### From .NET CLI

 - Restore:
 ```
 dotnet restore
 ```
 - Build:
 ```
 dotnet build
 ```
 - Run:
 ```
 dotnet run
 ```
 
 - Test:
 ```
 dotnet test
 ```

 ### Using Make with Docker (for mor information clic [here](https://www.gnu.org/software/make/))

 
 - Run Application:

 ```
 make run
 ```

 - Stop Application:
 
 ```
 make stop

 ```

 - Build Application:

 ```
 make build
 ```

 - Testing Application:
 ```
 make test
 ```

 - Test Coverage for the Application:
 ```
 make coverage
 ```

## Testing
Unit Testing Reports are exported and generated in Reports folder using Test Coverage and Report Generator packages.
- To generate Reports run:

```
make coverage
```

- To see reports go to './src/test/Reports/' and open index.htm