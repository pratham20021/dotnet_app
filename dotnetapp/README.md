# dotnetapp

A simple ASP.NET Core Web API built with .NET 8 Minimal API.

## Endpoints

| Method | Route      | Response                          |
|--------|------------|-----------------------------------|
| GET    | /          | `Welcome to .NET App`             |
| GET    | /about     | `This is a simple .NET application` |
| GET    | /api/data  | JSON array with id, name, role    |

## Run Locally

```bash
dotnet restore
dotnet run
```

App will be available at: http://localhost:5000

## Run with Docker

```bash
# Build the image
docker build -t dotnetapp .

# Run the container
docker run -p 5000:5000 dotnetapp
```

App will be available at: http://localhost:5000
