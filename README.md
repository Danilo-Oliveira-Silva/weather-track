<a id="readme-top"></a>

<div align="center">
    <img src="images/logo.png" alt="logo" width="400" />
    <p align="center">
        Full-stack project of a data viewer collected from various weather stations. 
    </p>
</div>

<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#architecture">Architecture</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>


## About The Project

<div align="center">
    <table border=0>
        <tr>
            <td><img src="images/measures-screen.png" width="500"></td>
            <td><img src="images/measure-screen.png" width="500"></td>
        </tr>
    </table>
</div>


Full-stack project of a data viewer for information collected from various weather stations. This study project is built using Angular 18 for the front-end, .NET for the back-end, and MySQL and MongoDB as databases.

The goal of the project is to build a data viewer for weather stations. These stations can be installed on farms, ports, airports, or large urban centers. Regardless of the data logger technology, the data should be consolidated into a single interface for the system administrator.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Built With

<table border=0>
    <tr>
        <td><img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"></td>
        <td><img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white"></td>
        <td><img src="https://img.shields.io/badge/MySQL-005C84?style=for-the-badge&logo=mysql&logoColor=white"></td>
        <td><img src="https://img.shields.io/badge/MongoDB-4EA94B?style=for-the-badge&logo=mongodb&logoColor=white"></td>
        <td><img src="https://img.shields.io/badge/Docker-2CA5E0?style=for-the-badge&logo=docker&logoColor=white"></td>
        <td><img src="https://img.shields.io/badge/Angular-DD0031?style=for-the-badge&logo=angular&logoColor=white"></td>
        <td><img src="https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white"></td>
    </tr>
</table>

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Getting Started

The project is using Docker containers and Docker Compose for orchestration.

### Prerequisites

- Docker >= v20.10.17
- Docker Compose >= v2.6.1

If you want to run the APIs and the front-end project outside of Docker, you will need to:

- .NET SDK 6.0
- Angular CLI 18

Furthermore, the project's functional map uses Mapbox. An API key will be required for the configuration of the `MeasureCard` component.

### Instalation

1. Clone the repo

```sh
git clone git@github.com:Danilo-Oliveira-Silva/weather-track.git
```

2. Run on docker

```sh
docker compose up -d --build
```

3. Access via browser on port `5004` 

    [Weather Track](http://localhost:5004)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Usage

This project requires authentication, and at this stage of development, only users with elevated access can view the data. You can either register a new account with all permissions or use a pre-registered account. The system comes with a seeder that includes two accounts you can use with the following credentials:

- `Email`: jane@test.com
- `Password`: 123

<div align="center">
    <table border=0>
        <tr>
            <td><img src="images/login-screen.png" width="500"></td>
            <td><img src="images/signup-screen.png" width="500"></td>
        </tr>
    </table>
</div>

After that, the system will display the meteorological data, which can be queried by date. By clicking on any record, the screen will show detailed data along with a satellite image of the coordinates where the weather station is installed. The image is provided by Mapbox, and you will need to use your own API key to view it.

<div align="center">
    <table border=0>
        <tr>
            <td><img src="images/measures-screen.png" width="500"></td>
            <td><img src="images/measure-screen.png" width="500"></td>
        </tr>
    </table>
</div>

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Architecture

This system works with several services for its operation:

- Auth API: This API was built in ASP.NET 6.0 using a layered architecture and Entity Framework Core to connect to a MySQL database, also in a Docker container. The repository pattern was used for database communication.

- Weather.API: This API, also built in ASP.NET, uses clean architecture. There are features to be developed, and not all will have the API as the presentation layer. Its infrastructure layer connects to a MongoDB database with a direct connection. The CQRS pattern and mediator were also used to invoke routes during its construction.

- Gateway API: Built in ASP.NET with the Ocelot package for routing, it serves as the single point of connection to other APIs in the container orchestration.

- WebApp: Front-end built with Angular 18 using components with Bootstrap 5.

<img src="images/diagram.png" />

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Contact

Danilo Silva

[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/danilodevs/)
[![website](https://img.shields.io/badge/website-580ea1?style=for-the-badge&logo=twitter&logoColor=white)](https://www.iamdanilo.com/)
[![bluesky](https://img.shields.io/badge/bluesky-1DA1F2?style=for-the-badge&logo=bluesky&logoColor=white)](https://bsky.app/profile/danilodev.bsky.social)
[![email](https://img.shields.io/static/v1?label=&message=E-mail&color=007722&style=for-the-badge&logo=mail.ru)](mailto:danilo.o.s@hotmail.com)
[![devto](https://img.shields.io/badge/dev.to-0A0A0A?style=for-the-badge&logo=devdotto&logoColor=white)](https://dev.to/danilosilva)

<p align="right">(<a href="#readme-top">back to top</a>)</p>