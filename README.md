<div align="center">
    <h1>Noroff Assignment 3: WEB API creation in ASP.NET CORE</h1>
    <img src="https://img.icons8.com/cotton/1x/api.png" width="128" alt="API">
</div>

[![license](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![standard-readme compliant](https://img.shields.io/badge/readme%20style-standard-brightgreen.svg?style=flat-square)](https://github.com/RichardLitt/standard-readme)

## Background information
This assignment is divided into two sections: Creating a database with **EF Code** first, and to create **WEB APIs** to interact with this database.

## Install
Download and install: 
* [SQL Server Management Studio](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)
* [.Net 4.5.1 or later](https://dotnet.microsoft.com/en-us/download/dotnet)
* [Docker Desktop (Optional)](https://www.docker.com/products/docker-desktop/)

## How to run

### Database

1. Running the command *update-database* in the Package Manager Console in Visual studio.

### Backend API

1. Build the docker image on local Docker using this command (or head over to Packages and registries -> Container Registry): <br/>   

    docker build -t registry.gitlab.com/richardstolen/backend-development-assignment-3 .

2. Open in Visual Studio the 'Backend_Development_Assignment_3.csproj' solution. Run the program by clicking on F5 or on start debugging.

## Maintainers

[@Ida Huun Michelsen](https://gitlab.com/IdaHuunMichelsen/)\
[@Richard Stølen](https://gitlab.com/richardstolen)

## Contributing

PRs accepted.

Small note: If editing the Readme, please conform to the [standard-readme](https://github.com/RichardLitt/standard-readme) specification.

## License

[MIT](../LICENSE) © Richard Stølen, Ida Huun Michelsen
