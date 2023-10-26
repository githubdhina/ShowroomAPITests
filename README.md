markdown
Copy code
# ShowroomAPITests

ShowroomAPITests is a SpecFlow-based test framework for testing the Showroom API. This framework helps you automate and execute API tests to ensure that the Showroom API functions correctly. It covers various scenarios, including endpoints, request types, and expected responses.

## Table of Contents
- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Running Tests](#running-tests)

## Getting Started

This section provides an overview of how to set up and run the ShowroomAPITests framework.

### Prerequisites

Before you begin, ensure you have the following dependencies installed:

- [.NET Core 6 SDK](https://dotnet.microsoft.com/download)
- [SpecFlow](https://specflow.org/)
- [Ensure the Showroom API Service is running]

### Installation

1. Clone the repository:

   ```sh
   git clone https://github.com/githubdhina/ShowroomAPITests.git
   change directory to the ShowroomService.csproj file directory after cloning
   
2. Build the project:

   ```sh
   dotnet build
   
3. Restore NuGet packages:

   ```sh
   dotnet restore

4. Running Tests
   Configure the BaseURL for the Showroom API on the file ClonedPath\ShowroomService\Helper\HTTPClientHelper.cs


5. Execute the tests using the following command:

   ```sh
   dotnet test
   The test results will be displayed in the console.
   A report with test result will be saved under the projects \bin\Debug\net6.0 folder


