# Setup
NAME            = find.water

# Source folder
SRCDIR       ?= $(CURDIR)/src

# App folder
APPDIR       ?= $(SRCDIR)/app/

# Test folder
TESTDIR       ?= $(SRCDIR)/test/

ifeq ($(OS),Windows_NT)
    OPEN := start
else
    UNAME := $(shell uname -s)
    ifeq ($(UNAME),Linux)
        OPEN := xdg-open
    endif
endif

# Main
run: docker-prep docker-run

stop: docker-stop

build: core-build
	
clean: core-clean

test: core-test

coverage: core-test-coverage

# .Net Core 
core-build:
	dotnet build $(APPDIR)
core-clean:
	dotnet clean $(APPDIR)
core-restore:
	dotnet restore $(APPDIR)
core-run:
	dotnet run -p $(APPDIR)/$(NAME).csproj
core-test:
	dotnet test $(TESTDIR)
core-test-coverage:
	dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover $(TESTDIR)/test.csproj
	reportgenerator -reports:$(TESTDIR)coverage.opencover.xml -targetdir:$(TESTDIR)Reports
    
# Docker
docker-stop:
	docker stop find_water
	docker rm find_water
docker-prep:
	docker build -t find_water .
docker-run:
	docker run --name find_water -i find_water