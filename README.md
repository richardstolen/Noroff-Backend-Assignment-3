<div align="center">
    <h1>Noroff Assignment 3: Data Persistence and Access</h1>
    <img src="https://static.javatpoint.com/tutorial/webapi/images/web-api-tutorial.png" width="128" alt="API">
</div>

[![license](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![standard-readme compliant](https://img.shields.io/badge/readme%20style-standard-brightgreen.svg?style=flat-square)](https://github.com/RichardLitt/standard-readme)

## Background information
This assignment is divided into two sections: creating database with SQL scripts and reading data with SQL client.

1. The SQL scripts to create a database is located in the 'Backend_Assignment_2_Appendix_B' folder. It holds one individual SQL script containing all the sequantial SQL queries, and in the 'SqlScripts' folder it has all the commands in separate SQL scripts.  These queries allow you to create a database, setup some tables in the database, add relationships to the tables, and then populate the tables with data. The database and its theme are surrounding **superheroes**.
2. The **ChinookReader** is located in the 'Backend_Assignment_2_Appendix_B' folder. It holds a C# console application that connects to a local database (**Chinook**) and executes **CRUD** queries. The app also uses the implementation of the repository pattern and is used to interact with the database.

## Install
Download and install: 
* [SQL Server Management Studio](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)
* [.Net 4.5.1 or later](https://dotnet.microsoft.com/en-us/download/dotnet)
* [Docker Desktop (Optional)]

## How to run

### Backend API

1. Build the docker image on local Docker.

2. Run project in visual studio.



## Maintainers

[@Ida Huun Michelsen](https://gitlab.com/IdaHuunMichelsen/)\
[@Richard Stølen](https://gitlab.com/richardstolen)

## Contributing

PRs accepted.

Small note: If editing the Readme, please conform to the [standard-readme](https://github.com/RichardLitt/standard-readme) specification.

## License

[MIT](../LICENSE) © Richard Stølen, Ida Huun Michelsen
